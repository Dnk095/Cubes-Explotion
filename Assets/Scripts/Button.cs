using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action UseMouseButton;

    private int _mouseButtonNumber;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
            UseMouseButton?.Invoke();
    }
}
