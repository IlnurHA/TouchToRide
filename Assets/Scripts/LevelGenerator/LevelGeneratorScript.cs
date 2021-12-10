using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneratorScript : MonoBehaviour
{
    public GameObject character;
    public GameObject platform;
    public GameObject coin;
    private bool _passivity = true;
    private string _direction = "forward";
    private int[] variables = new int[] {3, 0};
    public int platCounterGenerator = 0;

    private Color _platColor;
    private Color _oldColor;

    private float _counter = 0.5f;

    private void Awake()
    {
        int temp = character.GetComponent<CharacterNewScript>().platCounter;
        while (temp > platCounterGenerator)
        {
            platCounterGenerator += 1;
            Generator(0.5f, 0.1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (character.GetComponent<CharacterNewScript>().platCounter > platCounterGenerator)
        {
            platCounterGenerator += 1;
            Generator(0.5f, 0.1f);
            _counter = 0.05f;
            if (_counter >= 1) _counter = 1;
        }
        
    }

    public void SetColor(Color color)
    {
        _oldColor = _platColor;
        _platColor = color;
        _counter = 0.5f;
    }
    void Generator(float chanceRequirements1, float chanceRequirements2)
    {
        int[] tempVariables = new int[] {0, 0};
        float chance1 = Random.Range(0f, 1f);
        if (chance1 <= chanceRequirements1 && !_passivity)
        {
            _passivity = true;
            if (_direction == "forward")
            {
                float chance2 = Random.Range(0f, 1f);
                if (chance2 >= chanceRequirements1)
                {
                    _direction = "left";
                    tempVariables[1] += -1;
                }
                else
                {
                    _direction = "right";
                    tempVariables[1] += 1;
                }
            }
            else
            {
                _direction = "forward";
                tempVariables[0] += 1;
            }
        }
        else
        {
            _passivity = false;
            if (_direction == "forward") tempVariables[0] += 1;
            if (_direction == "right") tempVariables[1] += 1;
            if (_direction == "left") tempVariables[1] += -1;
        }

        float chance3 = Random.Range(0f, 1f);
        if (chance3 <= chanceRequirements2)
        {
            Instantiate(coin, new Vector3(-2 * variables[0], 1, 2 * variables[1]), Quaternion.identity);
        }

        GameObject plat = Instantiate(platform, new Vector3(-2 * variables[0], 0, 2 * variables[1]), Quaternion.identity);
        MeshRenderer[] meshRenderers = plat.GetComponents<MeshRenderer>();
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            if (meshRenderer.gameObject.CompareTag("PlatBorders"))
            {
                meshRenderer.material.color = Color.LerpUnclamped(_oldColor, _platColor, 1f * _counter);
            }
        }

        plat.GetComponent<PlatformScript>().WriteDirection(_direction, platCounterGenerator);
        variables[0] += tempVariables[0];
        variables[1] += tempVariables[1];
    }
}
