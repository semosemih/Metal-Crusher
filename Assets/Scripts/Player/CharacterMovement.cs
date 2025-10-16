using System;
using UnityEditor.UI;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public enum MovementState
    {
        Idle,
        Walking,
        Running
    };

    public float baseSpeed = 3f;
    public float runMultiplier = 2f;
    public float stamina = 100f;
    public MovementState state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state=MovementState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private bool canRun = true; //bunu update in icine koyarsan surekli true donerdi

    void HandleMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += new Vector3(0, 1, 0); // neden new koyduk basina? cunku Vector3 bir struct
        if (Input.GetKey(KeyCode.A)) direction += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.S)) direction += new Vector3(0, -1, 0);
        if (Input.GetKey(KeyCode.D)) direction += new Vector3(1, 0, 0);
        
        //artik kosmak eskisi gibi kolay olmamali
        //sartlar: stamina 0 a dusene kadar KOSABILIR
        //stamina 0 olduktan sonra 10 a cikana kadar KOSAMAZ
        //shift e basili tutunca kosmak ister
        
        bool wantsToRun = Input.GetKey(KeyCode.LeftShift);
        bool isMoving = direction != Vector3.zero;

        //simdi canRun false olunca burda wantstorun true olsa bile ismoving de true olsa bile o false oldugundan is running false olmali
        bool isRunning = wantsToRun && canRun && isMoving;
        
        if (isMoving) 
        {
            //speed e  burda karar vermek iyi. cunku running condition inda da speed karar verirsen iki farkli yerde position hesaplaman gerekcek 
            float speed = baseSpeed * (isRunning ? runMultiplier: 1f);
            transform.position += transform.TransformDirection(direction.normalized) * speed * Time.deltaTime;
            
            
            state = isRunning ? MovementState.Running : MovementState.Walking;
            
            if (isRunning)//kosamama islemi ne zaman gerceklescek? tabi ki kosarken
            {
                stamina -= Time.deltaTime * 20f;
                //tamam iyi kosuyo ama dedik ki stamina 0 olursa KOSAMAZ
                if (stamina <= 0f)
                {
                    stamina = 0f;
                    canRun = false;
                }
            }
        }
        else
        {
            state = MovementState.Idle;
        }

        if (stamina <100f)
        {
            float regenRate = 0f;

            if (state == MovementState.Idle)
                regenRate = 10f;
            else if (state == MovementState.Walking)
                regenRate = 5f;
            
            stamina += Time.deltaTime * regenRate;
            if (stamina > 100f) stamina = 100f;
            
        }
        
        if(!canRun && stamina>=10f) canRun = true;
        
    }
}
