using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : AbstractAnimator
{
    public void Hurt()
    {
        SetTrigger("hurt");
    }

    public void Shoot()
    {
        SetTrigger("shoot");
    }

    public void Move()
    {
        SetBool("moving", true);
    }

    public void Stop()
    {
        SetBool("moving", false);
    }

    public void Dead()
    {
        SetTrigger("dead");
    }
}
