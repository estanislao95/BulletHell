using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMessage : MonoBehaviour, IScreen
{
    public ScreenMessage nextScreen;
    public UnityEngine.UI.Image image;
    public void BTN_NextScreen()
    {
        ScreenManager.instance.Push(nextScreen);
    }

    public void BTN_Return()
    {
        ScreenManager.instance.Pop();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        SetTransparent(1f);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Transparent()
    {
        SetTransparent(0.2f);
    }

    void SetTransparent(float alpha)
    {
        var c = image.color;
        c.a = alpha;
        image.color = c;
    }
}
