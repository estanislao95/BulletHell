using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCounter : MonoBehaviour, IObserverFloat
{
    private void Start()
    {
        EnemyHandler pm = FindObjectOfType<EnemyHandler>();

        if (pm != null)
            FindObjectOfType<EnemyHandler>().Subscribe(this);
    }

    public void notify(float Answere)
    {
        FillLifeBar(Answere);
    }

    public void FillLifeBar(float bar)
    {
        UIManager.Instance.wavecounter(bar);
    }
}
