using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedGarlic = Instantiate(prefab);
        spawnedGarlic.transform.position = transform.position;
        spawnedGarlic.transform.SetParent(transform);
    }
}
