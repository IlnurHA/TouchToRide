using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public string _direction = "forward";
    public int platNumber = 0;
    public GameObject generator;
    public int deltaPlat;

    private void Awake()
    {
        generator = GameObject.FindWithTag("Generator");
    }

    public void WriteDirection(string direction, int number)
    {
        platNumber = number;
        _direction = direction;
    }

    public string GetDirection()
    {
        return _direction;
    }

    private void Update()
    {
        if (generator.GetComponent<LevelGeneratorScript>().platCounterGenerator - deltaPlat > platNumber)
        {
            Destroy(this.gameObject);
        }
    }
}
