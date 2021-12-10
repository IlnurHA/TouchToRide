using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AshScript : MonoBehaviour
{
    public AllColors col;
    public GameObject player;
    public GameObject cameraGameObject;
    public float offsetX = 1f, offsetY = 20f;

    public Color fogColor;
    private bool _lastBool = false;

    private bool _isAshed = false;

    private void Awake()
    {
        GetComponent<ParticleSystem>().Pause();
        offsetY = cameraGameObject.transform.position.y + 10f;
        GetComponentInChildren<ParticleSystemForceField>().endRange = 0;
    }

    private void FixedUpdate()
    {
        if (!_lastBool && cameraGameObject.GetComponent<CameraChangeBackgroundScript>().GetColor()
            .Equals(col.NetherBackgroundColor))
        {
            GetComponent<ParticleSystem>().Play();
            RenderSettings.fogColor = fogColor;
            RenderSettings.fogDensity = 0.08f;

            GetComponentInChildren<ParticleSystemForceField>().endRange = 5f;
            _lastBool = true;
            _isAshed = false;
        } else if (_lastBool && !cameraGameObject.GetComponent<CameraChangeBackgroundScript>().GetColor()
            .Equals(col.NetherBackgroundColor))
        {
            GetComponent<ParticleSystem>().Pause();
            GetComponentInChildren<ParticleSystemForceField>().endRange = 0f;
            RenderSettings.fogDensity = 0.05f;

            RenderSettings.fogColor = col.defaultFogColor;

            _lastBool = false;
            _isAshed = false;
        }
        else
        {
            _isAshed = true;
        }
        
        // if (cameraGameObject.GetComponent<CameraChangeBackgroundScript>().GetColor().Equals(col.NetherBackgroundColor))
        // {
        //     GetComponent<ParticleSystem>().Play();
        //     if (!RenderSettings.fog) RenderSettings.fog = true;
        //     RenderSettings.fogColor = fogColor;
        //
        //     GetComponentInChildren<ParticleSystemForceField>().endRange = 5f;
        //     _lastBool = true;
        // }
        // else if (_lastBool is true)
        // {
        //     RenderSettings.fog = false;
        //     GetComponent<ParticleSystem>().Pause();
        //     GetComponentInChildren<ParticleSystemForceField>().endRange = 0f;
        //
        //     _lastBool = false;
        //     _isAshed = false;
        // }

        if (!_isAshed) StartSpreadAsh();
        else EndSpreadAsh();


        Vector3 newPos = player.transform.position;
        newPos.y = offsetY;
        newPos.x -= offsetX;
        transform.position = newPos;
    }

    public void StartSpreadAsh()
    {
        GetComponent<ParticleSystem>().playbackSpeed = 2;
    }

    public void EndSpreadAsh()
    {
        GetComponent<ParticleSystem>().playbackSpeed = 0.05f;
    }
}