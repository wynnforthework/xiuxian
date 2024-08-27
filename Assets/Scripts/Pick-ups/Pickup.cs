using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, ICollectible
{
    protected bool hasBeenCollected = false;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public virtual void Collect()
    {
        hasBeenCollected = true;
    }
}
