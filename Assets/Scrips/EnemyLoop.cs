using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoop : MonoBehaviour
{
    [SerializeField] float offset = 0.5f;
    private void OnTriggerExit2D(Collider2D collision)
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

        if (position.x > BorderManager.Instance.MaxX())
        {
            position.x = BorderManager.Instance.MinX() - offset;
        }
        else if (position.x < BorderManager.Instance.MinX())
        {
            position.x = BorderManager.Instance.MaxX() + offset;
        }

        if (position.y > BorderManager.Instance.MaxY())
        {
            position.y = BorderManager.Instance.MinY() - offset;
        }
        else if (position.y < BorderManager.Instance.MinY())
        {
            position.y = BorderManager.Instance.MaxY() + offset; 
        }

        t.position = position;
    }
}
