using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class EnemyManager : MonoBehaviour
{

    public static EnemyManager instance;

    [SerializeField]
    EnemyData[] _EnemyObject;
    Dictionary<EnemyType, EnemyData> _dictionary = new Dictionary<EnemyType, EnemyData>();

    private void Awake()
    {
        instance = this;


        for (int i = 0; i < _EnemyObject.Length; i++)
        {
            _EnemyObject[i].factory = new Factory<EnemyAbstract>(_EnemyObject[i].Drop, TurnOn, TurnOff, _EnemyObject[i].stock);
            _dictionary.Add(_EnemyObject[i].type, _EnemyObject[i]);
        }


    }

    public void TurnOn(EnemyAbstract p)
    {
        p.TurnOn();
    }

    public void TurnOff(EnemyAbstract p)
    {
        p.TurnOff();
    }

    public void SpawnEnemy(Transform t, EnemyType type)
    {
        /*EnemyType enemy = type;

        print("spawning " + enemy.ToString());
        var b = _dictionary[enemy].factory.GetObject();
        b.Create(_dictionary[enemy].factory);
        b.transform.position = t.position;
        b.transform.rotation = t.rotation;*/

        EnemyAbstract enem = SpawnAndSaveEnemy(t, type); //REVISAR - que tan optimo es esto? Es mas optimo guardar una variable temporal que capaz no se use,
                                                         // o duplicar un codigo dos veces?

    }

    public EnemyAbstract SpawnAndSaveEnemy(Transform t, EnemyType type)
    {
        EnemyType enemy = type;

        print("spawning " + enemy.ToString());
        var b = _dictionary[enemy].factory.GetObject();
        b.transform.position = t.position;
        b.transform.rotation = t.rotation;
        b.Create(_dictionary[enemy].factory);
        b.Prepare();

        return b;
    }

    public Factory<EnemyAbstract> AddToPool(EnemyAbstract enemy, EnemyType type)
    {
        _dictionary[type].factory.ReturnObject(enemy);

        return _dictionary[type].factory;
    }


}

public enum EnemyType
{
    basic,
    diagonal
}

[System.Serializable]
public struct EnemyData
{
    public EnemyType type;
    public EnemyAbstract enemyObject;
    public Factory<EnemyAbstract> factory;
    public int stock;

    public EnemyAbstract Drop()
    {
        EnemyAbstract enemy = GameObject.Instantiate(enemyObject);

        return enemy;
    }
}
