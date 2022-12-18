using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnimator : MonoBehaviour
{
    [SerializeField] Animator anim;
    protected void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    protected void SetBool(string name, bool value = true)
    {
        anim.SetBool(name, value);
    }
}
