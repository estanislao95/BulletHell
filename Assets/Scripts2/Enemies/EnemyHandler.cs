using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class EnemyHandler : MonoBehaviour, IObservableFloat
{
    public List<WaveData> waves;
    public int currentWave;
    [SerializeField]
    List<IObserverFloat> _allObservers = new List<IObserverFloat>();
    public List<EnemyAbstract> waveEnemyList = new List<EnemyAbstract>();
    public static EnemyHandler instance;

    bool hasStarted = false; //TEMP.
    public void Start()
    {
        instance = this;
        RestartGame.Instance.handler = this;
        NotifyToObserver(currentWave);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasStarted)  //TEMP. BORRAR PREVIO A ENTREGA.
        {
            //SpawnEnemy(transform, EnemyType.basic);

            WaveStart(waves[currentWave]);
            hasStarted = true;
        }
    }

    public void SpawnEnemy(Transform transform, EnemyType type)
    {
        EnemyManager.instance.SpawnEnemy(transform, type);
    }

    public void Subscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);
    }

    public void Unsubscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObserver(float life)
    {
        for (int i = 0; i < _allObservers.Count; i++)
        {
            _allObservers[i].notify(life);
        }
    }

    #region Wave

    public void WaveStart(WaveData wd)
    {
        SummonWave(wd.positions, wd.types);
        NotifyToObserver(currentWave);
    }

    public void SummonWave(Transform[] transforms, EnemyType[] type)
    {
        waveEnemyList.Clear();

        for (int i = 0; i < transforms.Length; i++)
        {
            int count = i;
            if (count > type.Length - 1) count = type.Length - 1; //de esta manera podemos poner muchos tipos diferentes de enemigos,
                                                                  //o poner solo un tipo y lo aplicara a todos.
                                                                  //si se quiere 2 de un tipo y el resto de otro, se deberia poner primero los transforms y tipos mas infrecuentes, 
                                                                  //y cuando nos quedamos con tipo 5 de el mismo tipo, solo ponemos el tipo 1 vez al final del array.

            EnemyAbstract b = EnemyManager.instance.SpawnAndSaveEnemy(transforms[i], type[count]);
            b.AssignHandler(this);
            waveEnemyList.Add(b);
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
        currentWave++;
        if (currentWave < waves.Count)
            WaveStart(waves[currentWave]); //Temp?
        else
            LastWaveFinished();
    }

    public void LastWaveFinished()
    {
        MenuManager.instance.Win();
    }

    public void restartwave()
    {

    }

    #endregion
}

[System.Serializable]
public struct WaveData
{
    public Transform[] positions;
    public EnemyType[] types;
}
