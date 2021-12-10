using UnityEngine;

public class SnowScript : MonoBehaviour
{
    public AllColors col;
    public CameraChangeBackgroundScript cam;
    public GameObject player;
    public GameObject cameraGameObject;
    public float offsetX = 5000f, offsetY = 20f;

    public Color fogColor;

    private bool _lastBool = false;
    private Color _currentColor, _nextColor;

    private float _colorCounter = 0.5f;


    private void Awake()
    {
        GetComponent<ParticleSystem>().Pause();
        offsetY = cameraGameObject.transform.position.y + 10f;
        GetComponentInChildren<ParticleSystemForceField>().endRange = 0;
        _colorCounter = 1f;
        _nextColor = col.defaultFogColor;
        _currentColor = col.defaultFogColor;
    }

    private void FixedUpdate()
    {
        if (!_lastBool && cameraGameObject.GetComponent<CameraChangeBackgroundScript>().GetColor()
            .Equals(col.WinterBackgroundColor))
        {
            GetComponent<ParticleSystem>().Play();
            RenderSettings.fogDensity = 0.08f;
            
            _currentColor = _nextColor;
            _nextColor = fogColor;
            _colorCounter = 0.5f;

            GetComponentInChildren<ParticleSystemForceField>().endRange = 50f;
            _lastBool = true;
        } else if (_lastBool && !cameraGameObject.GetComponent<CameraChangeBackgroundScript>().GetColor()
            .Equals(col.WinterBackgroundColor))
        {
            GetComponent<ParticleSystem>().Pause();
            GetComponentInChildren<ParticleSystemForceField>().endRange = 0f;
            RenderSettings.fogDensity = 0.05f;

            _currentColor = _nextColor;
            _nextColor = col.defaultFogColor;
            _colorCounter = 0.5f;

            _lastBool = false;
        }
        // if (cam.GetColor().Equals(col.WinterBackgroundColor))
        // {
        //     GetComponent<ParticleSystem>().Play();
        //     if (!RenderSettings.fog) RenderSettings.fog = true;
        //     RenderSettings.fogColor = fogColor;
        //
        //     GetComponentInChildren<ParticleSystemForceField>().endRange = 50f;
        //     _lastBool = true;
        // }
        // else if (_lastBool is true)
        // {
        //     RenderSettings.fog = false;
        //     GetComponent<ParticleSystem>().Pause();
        //     GetComponentInChildren<ParticleSystemForceField>().endRange = 0f;
        //
        //     _lastBool = false;
        // }

        if (_colorCounter < 1)
        {
            _colorCounter += 0.01f;
            RenderSettings.fogColor = Color.LerpUnclamped(_currentColor, _nextColor, _colorCounter);
        }
        
        Vector3 newPos = player.transform.position;
        newPos.y = offsetY;
        newPos.x -= offsetX;
        transform.position = newPos;
    }

    // private float GetMinColor(Color color)
    // {
    //     float r = color.r, g = color.g, b = color.b;
    //     if (r > g)
    //     {
    //         if (g > b) return b;
    //         return g;
    //     }
    //     else
    //     {
    //         if (r > b) return b;
    //         return r;
    //     }
    //     
    // }
}