using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void Move();
    public void SetTimer(float t);
    public float GetTimer();

    public void SetAnim(CharacterAnimator anim);
}
