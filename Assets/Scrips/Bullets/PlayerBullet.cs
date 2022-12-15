using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class PlayerBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Ilife target = collision.GetComponent<Ilife>();

        if (target != null)
        {
            target.Damage(_damage);
            Deactivated();
        }
    }
}
