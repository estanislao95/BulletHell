using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int maxTime;
    float _counter;
    [SerializeField]
    int damage = 2;

    public GameObject paricles;

    Factory<Bullet> _referenceBack;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        _counter += Time.deltaTime;

        if (_counter >= maxTime)
        {
            TurnOff(this);
            _referenceBack.ReturnObject(this);
        }

    }

    public void ResetBullet()
    {
        _counter = 0;
    }

    public void Create(Factory<Bullet> op)
    {
        _referenceBack = op;
    }

    public static void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(Bullet b)
    {
        b.ResetBullet();
        b.gameObject.SetActive(false);

    }
}
