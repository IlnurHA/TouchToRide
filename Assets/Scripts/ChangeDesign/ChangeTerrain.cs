using System;
using UnityEngine;

public class ChangeTerrain : MonoBehaviour
{
    private bool _change = false;
    private bool _startTransition = false;

    public GameObject backgroundObject;
    public GameObject levelGenerator;
    public GameObject allColors;

    private Tuple<Color, Color>[] TerrainsColors;

    public void SetToChange()
    {
        _change = true;
    }

    public void SetToTransitionColor()
    {
        _startTransition = true;
    }
    private void Update()
    {
        if (_change)
        {
            Tuple<Color, Color> colors = allColors.GetComponent<AllColors>().GetRandomColor();
            backgroundObject.GetComponent<CameraChangeBackgroundScript>().SetColor(colors.Item1);
            levelGenerator.GetComponent<LevelGeneratorScript>().SetColor(colors.Item2);
            _change = false;
        }

        if (_startTransition)
        {
            Tuple<Color, Color> colors = allColors.GetComponent<AllColors>().GetTransitionColor();
            backgroundObject.GetComponent<CameraChangeBackgroundScript>().SetColor(colors.Item1);
            levelGenerator.GetComponent<LevelGeneratorScript>().SetColor(colors.Item2);
            _startTransition = false;
        }
    }
}
