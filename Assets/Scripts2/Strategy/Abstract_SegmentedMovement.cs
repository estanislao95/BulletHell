using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstract_SegmentedMovement : Enemy_Movement
{
    protected float timer = 0;

    public float[] CalculateTime(float[] timePhase)
    {
        float sum = 0;
        for (int i = 0; i < timePhase.Length; i++)
        {
            Debug.Log("timer" + i + " : " +timePhase[i]);
            timePhase[i] += sum;
            sum += timePhase[i];
        }

        return timePhase;
    }

    public override void SetTimer(float t)
    {
        timer = t;
    }

    public override float GetTimer()
    {
        return timer;
    }
}
