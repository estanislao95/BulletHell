using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class item : MonoBehaviour, IFactoried<item>
{
    protected Factory<item> _referenceBack;

    [SerializeField] float fallSpeed;

    private void Update()
    {
        transform.position += -transform.up * fallSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SomethingEnter(collision);

    }

    public void SomethingEnter(Collider2D collision)
    {
        IUpgrades entity = collision.GetComponent<IUpgrades>();

        if (entity != null)
        {
            UpgradePlayer(entity);
            Destroy(this.gameObject);
        }
    }

    public virtual void UpgradePlayer(IUpgrades entity)
    {
        //entity.Upgrades(new FireShot(entity.getPowerup())); //TEMP.

    }

    #region Factory
    public virtual void Activated()
    {
    }

    public virtual void Deactivated()
    {
        _referenceBack.ReturnObject(this);
    }
    public void Create(Factory<item> op)
    {
        _referenceBack = op;
        Activated();
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        Activated();
    }
    #endregion

}
