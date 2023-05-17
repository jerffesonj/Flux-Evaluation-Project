using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColor : MonoBehaviour
{
    public List<ColorScriptable> colors;

    public Material[] playerMaterials;

    void Start()
    {
        int randomIndex = Random.Range(0,colors.Count);

        ColorScriptable currentColor = colors[randomIndex];
        ChangePlayerMaterialsColor(currentColor.bodyColor, currentColor.armsColor, currentColor.legsColor);
    }

    private void OnDisable()
    {
        ChangePlayerMaterialsColor(Color.white, Color.white, Color.white);
    }

    void ChangePlayerMaterialsColor(Color bodyColor, Color armsColor, Color legsColor)
    {
        playerMaterials[0].color = bodyColor;
        playerMaterials[1].color = armsColor;
        playerMaterials[2].color = legsColor;
    }
}
