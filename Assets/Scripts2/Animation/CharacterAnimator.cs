using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : AbstractAnimator
{
    public void Prepare()
    {
        SetBool("hurt", false);
        SetBool("moving", false);
        SetBool("dead", false);
    }

    public void Hurt()
    {
        SetBool("hurt", true);
    }

    public void Fine()
    {
        SetBool("hurt", false);
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
        SetBool("dead", true);
    }
}
