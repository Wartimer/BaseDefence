using Data;
using UnityEngine;

internal class UIController
{
    private UIData _data;
    private UIView _canvas;

    public UIView Canvas => _canvas;

    public UIController(UIData data)
    {
        _data = data;
    }

    public void SpawnUI()
    {
        _canvas = _data.PlaceForUi.GetComponent<UIView>();
    }
}