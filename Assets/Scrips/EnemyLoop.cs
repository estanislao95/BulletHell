using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoop : MonoBehaviour
{
    [SerializeField] Transform Top;
    [SerializeField] Transform Left;
    [SerializeField] Transform Right;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyAbstract ea = collision.GetComponent<EnemyAbstract>();

        if (ea != null)
        {
            Teleport(ea.transform);
        }
    }

    public void Teleport(Transform t)
    {
        Vector3 position = t.position;

        position.y = Top.position.y;

        if (position.x > Right.position.x)
        {
            position.x = Left.position.x;
        }

        else if (position.x < Left.position.x)
        {
            position.x = Right.position.x;
        }

        t.position = position;
    }
}
