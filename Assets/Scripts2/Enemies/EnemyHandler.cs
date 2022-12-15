using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class EnemyHandler : MonoBehaviour
{
    public List<WaveData> waves;
    public int currentWave;

    public List<EnemyAbstract> waveEnemyList = new List<EnemyAbstract>();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  //TEMP. BORRAR PREVIO A ENTREGA.
        {
            //SpawnEnemy(transform, EnemyType.basic);

            WaveStart(waves[currentWave]);
        }
    }

    public void SpawnEnemy(Transform transform, EnemyType type)
    {
        EnemyManager.instance.SpawnEnemy(transform, type);
    }

    #region Wave

    public void WaveStart(WaveData wd)
    {
        SummonWave(wd.positions, wd.types);
    }

    public void SummonWave(Transform[] transforms, EnemyType[] type)
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            int count = i;
            if (count > type.Length - 1) count = type.Length - 1; //de esta manera podemos poner muchos tipos diferentes de enemigos,
                                                                  //o poner solo un tipo y lo aplicara a todos.
                                                                  //si se quiere 2 de un tipo y el resto de otro, se deberia poner primero los transforms y tipos mas infrecuentes, 
                                                                  //y cuando nos quedamos con tipo 5 de el mismo tipo, solo ponemos el tipo 1 vez al final del array.

            EnemyAbstract b = EnemyManager.instance.SpawnAndSaveEnemy(transforms[i], type[count]);
            b.assignHandler(this);
        }
    }

    public void EnemyKilled(EnemyAbstract b)
    {
        waveEnemyList.Remove(b);

        if (waveEnemyList.Count == 0)
        {
            WaveFinished();
        }
    }

    public void WaveFinished()
    {
        currentWave += 1;
    }

    #endregion
}

[System.Serializable]
public struct WaveData
{
    public Transform[] positions;
    public EnemyType[] types;
}
