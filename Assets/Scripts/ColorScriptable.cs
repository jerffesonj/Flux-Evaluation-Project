using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Color", menuName = "Character Color/Color", order = 0)]
public class ColorScriptable : ScriptableObject
{
    public Color bodyColor;
    public Color armsColor;
    public Color legsColor;

    public void SetColors(Color body, Color arms, Color legs)
    {
        bodyColor = body;
        armsColor = arms;
        legsColor = legs;

    }
}
