using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : Singleton<UIManager>
{
    public Image _Lifebar;
    public Text _wavecounter;

    public void Lifebar(float fill)
    {
        _Lifebar.fillAmount = fill;
    }

    public void wavecounter(float count)
    {
        _wavecounter.text = "Wave " + count;
    }
}
