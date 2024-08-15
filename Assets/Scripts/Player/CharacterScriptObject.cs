using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptObject", menuName = "ScriptableObject/Character")]
public class CharacterScriptObject : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon
    {
        get => startingWeapon;
        private set => startingWeapon = value;
    }

    [SerializeField]
    private float maxHealth;

    public float MaxHealth
    {
        get => maxHealth;
        private set => maxHealth = value;
    }

    [SerializeField]
    private float recovery;

    public float Recovery
    {
        get => recovery;
        private set => recovery = value;
    }
    
    [SerializeField]
    private float moveSpeed;

    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    [SerializeField]
    private float might;

    public float Might
    {
        get => might;
        private set => might = value;
    }

    [SerializeField]
    private float projectileSpeed;

    public float ProjectileSpeed
    {
        get => projectileSpeed;
        private set => projectileSpeed = value;
    }

}
