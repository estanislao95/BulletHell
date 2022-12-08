using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoried<T>
{
    public void Create(Factory<T> op);

    public void TurnOn();
    public void TurnOff();
}
