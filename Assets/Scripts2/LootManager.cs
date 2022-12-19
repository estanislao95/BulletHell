using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{

    public static LootManager instance;

    /*LootDrop _enemyDrops;
    [SerializeField]
    LootTable _lootTable;*/

    [SerializeField]
    LootData[] _pickUpObject;
    Dictionary<LootType, LootData> _dictionary = new Dictionary<LootType, LootData>();

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < _pickUpObject.Length; i++)
        {
            if (_pickUpObject[i].type == LootType.none) continue; //it has the object in the table as a possibility, but won't create it because its literally nothing

            _pickUpObject[i].factory = new Factory<item>(_pickUpObject[i].Drop, TurnOn, TurnOff, _pickUpObject[i].weight);
            _dictionary.Add(_pickUpObject[i].type, _pickUpObject[i]);
        }


    }

    public void TurnOn(item p)
    {
        p.TurnOn();
    }

    public void TurnOff(item p)
    {
        p.TurnOff();
    }

    public void DropLoot(Transform t, LootType lt = LootType.none)
    {
        if (lt == LootType.none) lt = _pickUpObject[Random.Range(0, _pickUpObject.Length)].type; //if none specified, pick a random one

        if (lt == LootType.none) return; //if result is still none, dont spawn anything.

        SpawnLoot(t, lt);

    }

    protected void SpawnLoot(Transform t, LootType loot)
    {
        //print("dropping " + loot.ToString());
        var b = _dictionary[loot].factory.GetObject();
        b.Create(_dictionary[loot].factory);
        b.transform.position = t.position;
    }

    public Factory<item> AddToPool(item loot, LootType lt)
    {
        _dictionary[lt].factory.ReturnObject(loot);

        return _dictionary[lt].factory;
    }


}

public enum LootType
{
    multiShot,
    fireShot,
    laserShot,
    rocketShot,
    none
}

[System.Serializable]
public struct LootData
{
    public LootType type;
    public item pickupObject;
    public int weight;
    public Factory<item> factory;

    public item Drop()
    {
        item loot = GameObject.Instantiate(pickupObject);

        return loot;
    }
}
