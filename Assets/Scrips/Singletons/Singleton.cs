using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credito a Iara Libert, que escribio este codigo el cuatrimestre anterior para otro trabajo y ahora lo estoy reusando.
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance;

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
            PersonalAwake();
        }
    }
    
    public virtual void PersonalAwake()
    {

    }
}
