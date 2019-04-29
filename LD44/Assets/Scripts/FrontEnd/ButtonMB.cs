using System;
using UnityEngine;

public class ButtonMB : MonoBehaviour
{
    public Action OnClick;

    private void OnMouseUp()
    {
        OnClick.Invoke();
    }
}
