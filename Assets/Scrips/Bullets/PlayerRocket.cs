using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : Bullet
{

    public BoxCollider2D explotion;
    public GameObject sprite;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        List<Ilife> targets = new List<Ilife>();
        targets.Add(collision.GetComponent<Ilife>());

        Ilife target = collision.GetComponent<Ilife>();



        if (target != null)
        {
            explotion.gameObject.SetActive(true);
            foreach (Ilife item in targets)
            {
                target.Damage(_damage);
                Damage(1);
            }
        }
    }
}
