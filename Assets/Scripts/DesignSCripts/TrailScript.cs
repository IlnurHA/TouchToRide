using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        UnityEngine.TrailRenderer component = GetComponent<TrailRenderer>();
        Color color = player.GetComponent<MeshRenderer>().material.color;

        component.startColor = color;
        component.endColor = color;
        component.time = 10f;
    }
}
