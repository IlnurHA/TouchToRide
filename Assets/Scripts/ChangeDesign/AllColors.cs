using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AllColors : MonoBehaviour
{
    public Color WinterBackgroundColor;
    public Color WinterPlatColor;

    public Color NetherBackgroundColor;
    public Color NetherPlatColor;

    public Color DefaultBackgroundColor;
    public Color DefaultPlatColor;

    public Color TransitionBackgroundColor;
    public Color TransitionPlatColor;

    public Color defaultFogColor;

    private static Tuple<Color, Color> MakeTupleFromColors(Color back, Color plat)
    {
        return new Tuple<Color, Color>(back, plat);
    }

    public Tuple<Color, Color>[] GetAllColors()
    {

        Tuple<Color, Color>[] colors =
        {
            MakeTupleFromColors(DefaultBackgroundColor, DefaultPlatColor),
            MakeTupleFromColors(WinterBackgroundColor, WinterPlatColor),
            MakeTupleFromColors(NetherBackgroundColor, NetherPlatColor)
        };
        return colors;
    }

    public Tuple<Color, Color> GetRandomColor()
    {
        float chance = Random.Range(0, 100f);
        if (chance < 10f)
        {
            return GetAllColors()[2];
        }
        if (chance < 40f)
        {
            return GetAllColors()[1];
        }
        return GetAllColors()[0];
    }

    public Tuple<Color, Color> GetTransitionColor()
    {
        return MakeTupleFromColors(TransitionBackgroundColor, TransitionPlatColor);
    }
}
