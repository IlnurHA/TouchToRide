using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CoinScipt : MonoBehaviour
{
    private Vector3 _pos;
    private float _counter = 0;

    public float maxOffsetY;
    public float coinSpeed;
    public float rotationSpeed;


    private void Awake()
    {
        _pos = transform.position;
    }

    private void FixedUpdate()
    {
        _counter += coinSpeed * Time.deltaTime;
        
        transform.position = new Vector3(_pos.x, _pos.y + maxOffsetY * Mathf.Sin(_counter), _pos.z);
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
