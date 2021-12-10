using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScripy : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        UnityEngine.LineRenderer component = GetComponent<LineRenderer>();
        Color color = player.GetComponent<MeshRenderer>().material.color;
        component.startColor = color;
        GetComponent<LineRenderer>().startColor = color;
        GetComponent<LineRenderer>().endColor = color;
        
        GetComponent<LineRenderer>().endWidth = 0;
    }
}
