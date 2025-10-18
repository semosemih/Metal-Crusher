using System;
using Player;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public IPlayerState currentState;

    public void ChangeState(IPlayerState newState)
    {
        currentState?.OnExit(this); //this derken su anda unity deki bu component in eklendigi game object i refer ediyoruz
        currentState = newState;
        currentState.OnEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.OnUpdate(this);
    }
}
