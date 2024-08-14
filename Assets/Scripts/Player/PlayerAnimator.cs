using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public enum PlayerAnimatorState
    {
        Move
    }
    private Animator am;
    private PlayerMovement pm;
    SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool(nameof(PlayerAnimatorState.Move), true);
            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool(nameof(PlayerAnimatorState.Move), false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
