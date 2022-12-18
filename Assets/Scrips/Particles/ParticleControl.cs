using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    float _counter;
    Factory<ParticleControl> _referenceBack;

    [SerializeField]
    float timetodie = 0;

    [SerializeField]
    ParticleSystem control;

    void Update()
    {
        _counter += Time.deltaTime;
        if (timetodie <= _counter)
        {
            //TurnOff(this);
            _referenceBack.ReturnObject(this);
        }
    }


    public void ResetBullet()
    {
        _counter = 0;
    }

    public void Create(Factory<ParticleControl> op)
    {
        _referenceBack = op;
    }

    public static void TurnOn(ParticleControl b)
    {
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(ParticleControl b)
    {
        b.ResetBullet();
        b.gameObject.SetActive(false);

    }


}
