using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour, IObserverFloat
{
    public float totalhp;

    private void Start()
    {
        Player pm = FindObjectOfType<Player>();

        if (pm != null)
            FindObjectOfType<Player>().Subscribe(this);
    }

    public void notify(float Answere)
    {
        FillLifeBar(Answere);
    }

    public void FillLifeBar(float bar)
    {
        totalhp = bar / FlyweightPointer.Player.maxLife;
        UIManager.Instance.Lifebar(totalhp);
    }
}
