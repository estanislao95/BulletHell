using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] Image _Lifebar;
    [SerializeField] Text _wavecounter;
    [SerializeField] Text _PointCounter;



    [SerializeField] ConfirmScreen confirmScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void Lifebar(float fill)
    {
        _Lifebar.fillAmount = fill;
    }

    public void wavecounter(float count)
    {
        _wavecounter.text = "Wave " + count;
    }

    public void pointcounter(int points)
    {
        _PointCounter.text = "Points " + points;
    }

    public ConfirmScreen ConfirmScreen()
    {
        return confirmScreen;
    }
    public void PushConfirmScreen()
    {
        ScreenManager.instance.Push(confirmScreen);
    }

}
