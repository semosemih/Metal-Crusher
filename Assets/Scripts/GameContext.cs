using Metal;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    public static GameContext Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public PlayerModel Player;
    public WeaponModel Weapons;

    private void OnEnable()
    {
        Player = new PlayerModel();
        Weapons = new WeaponModel();
    }
}
