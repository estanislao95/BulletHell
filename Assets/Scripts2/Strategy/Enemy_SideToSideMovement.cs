using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SideToSideMovement : Enemy_Movement
{
    Transform _transform;
    float _startSpeed;
    float _exitSpeed;
    Vector3 _dir;
    Transform _HolderRot;


    enum Phase
    {
        Left,
        Right
    }

    Phase _phase = Phase.Left;

    float timer = 0;
    float _frequency;




    public Enemy_SideToSideMovement(Transform HolderRot, Transform transform, Vector3 dir, ShootMethod shoot, float startSpeed = 2, float exitSpeed = 1, float frequency = 1)
    {
        _transform = transform;
        _startSpeed = startSpeed;
        _exitSpeed = exitSpeed;
        _dir = dir;
        _shoot = shoot;
        _frequency = frequency;
        _HolderRot = HolderRot;
    }



    public override void Move()
    {
        timer += Time.deltaTime;
        if (timer >= _frequency)
        {
            _anim.Shoot();
            _shoot(_type);
            _HolderRot.transform.Rotate(new Vector3(0,0, _HolderRot.transform.rotation.z + 45));
            timer = 0;
        }

        switch (_phase)
        {
            case Phase.Left:
                Phase1();
                return;

            case Phase.Right:
                Phase2();
                return;
        }
    }

    void Phase1()
    {
        _transform.position += _dir * _startSpeed * Time.deltaTime;


        if (_anim != null)
            _anim.Move();



        if (_transform.position.x >= BorderManager.Instance.MaxX())
            _phase = Phase.Right;

    }

    void Phase2()
    {
        _transform.position += -_dir * _startSpeed * Time.deltaTime;

        if (_anim != null)
            _anim.Move();

        if (_transform.position.x <= BorderManager.Instance.MinX())
            _phase = Phase.Left;

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
