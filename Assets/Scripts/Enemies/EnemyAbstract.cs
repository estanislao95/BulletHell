using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    [SerializeField] protected IMovement[] _strategies;

    [SerializeField] protected int _hp = 1;
    [SerializeField] protected float _speed = 1;

    [SerializeField] protected ProyectileType _proyectileType;
}
