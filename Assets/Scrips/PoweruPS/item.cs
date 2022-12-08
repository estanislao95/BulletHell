using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField]
    int ups = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cannons entity = collision.GetComponent<Cannons>();

        if (entity != null)
        {
            Debug.Log("a");
            entity.Upgrades(ups);
            Destroy(this.gameObject);
        }

    }


}
