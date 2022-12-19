using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBullet : MonoBehaviour
{
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        ProyectileAbstract bullet = collision.GetComponent<ProyectileAbstract>();

        if (bullet != null)
        {
            
            bullet.Deactivated();
        }
    }
}
