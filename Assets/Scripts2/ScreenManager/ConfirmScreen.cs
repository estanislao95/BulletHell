using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmScreen : ScreenMessage
{
    public delegate void ConfirmAction();
    public ConfirmAction _confirmAction;

    public UnityEngine.UI.Text text;

    public void SetConfirmAction(ConfirmAction confirmAction)
    {
        _confirmAction = confirmAction;
    }

    public void SetText(string word)
    {
        text.text = word;
    }

    public void BTN_Confirm()
    {
        _confirmAction();
        ScreenManager.instance.Clear();
    }
}
