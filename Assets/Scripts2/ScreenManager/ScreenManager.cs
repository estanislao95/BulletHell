using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    Stack<IScreen> _screens = new Stack<IScreen>();
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void Push(IScreen screen)
    {
        if (screen == null) return;

        if (_screens.Count > 0)
            _screens.Peek().Transparent();
        _screens.Push(screen);
        screen.Activate();
    }

    public void Pop()
    {
        if (_screens.Count <= 0) return;

        _screens.Pop().Deactivate();

        if (_screens.Count > 1)
            _screens.Peek().Activate();
        else
            Clear();
    }

    public void Clear()
    {
        for (int i = 0; i < _screens.Count; i++)
        {
            Pop();
        }
    }
}
