using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;

    public float damage;
    public float speed;
    public float cooldownDuration;
    private float currentCooldown;
    public int pierce;

    protected PlayerMovement pm;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown<=0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
