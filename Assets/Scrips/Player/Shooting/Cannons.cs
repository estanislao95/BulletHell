using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannons : MonoBehaviour, IUpgrades
{

    public List<ICannonUpgrades> _cannons = CannonsUpgrades.upgrades;

    [SerializeField]
    float timer, MaxTimer;
    [SerializeField]
    int timermultipler, upgrade;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += timermultipler * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int tepm = upgrade;

            tepm++;

            if (tepm > _cannons.Count - 1)
            {
                upgrade = _cannons.Count - 1;
            }
            else
            {
                upgrade = tepm;
            }
            return;
        }


        if (Input.GetKey(KeyCode.Space) && timer >= MaxTimer)
        {
            _cannons[upgrade].shooting();
            timer = 0;
        }
    }


    public void Upgrades(int up)
    {
        int tepm = upgrade;

        tepm += up;

        if (tepm > _cannons.Count - 1)
        {
            upgrade = _cannons.Count - 1;
        }
        else
        {
            upgrade = tepm;
        }
    }
}
