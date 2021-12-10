using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class CameraChangeBackgroundScript : MonoBehaviour
{
    private Color _color;
    private Color _oldColor;
    private float _counter = 1f;
    private bool _game = true;

    public AllColors col;
    public CharacterNewScript characterNewScript;

    private void Awake()
    {
        _oldColor = col.DefaultBackgroundColor;
        _color = col.DefaultBackgroundColor;
    }

    public void SetColor(Color color)
    {
        _oldColor = _color;
        _color = color;
        _counter = 0.5f;
    }

    public Color GetColor()
    {
        return _color;
    }
    private void FixedUpdate()
    {
        _game = characterNewScript.GetGameRunning();
        _counter += 0.05f;
        if (_counter > 1) _counter = 1;

        GetComponent<Camera>().backgroundColor = Color.LerpUnclamped(_oldColor, _color, 1f * _counter);

        GetComponent<CinemachineBrain>().enabled = _game;
    }
}
