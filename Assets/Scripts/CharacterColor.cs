using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColor : MonoBehaviour
{
    public List<ColorScriptable> colors;

    public Material[] playerMaterials;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0,colors.Count);

        playerMaterials[0].color = colors[randomIndex].bodyColor;
        playerMaterials[1].color = colors[randomIndex].armsColor;
        playerMaterials[2].color = colors[randomIndex].legsColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        playerMaterials[0].color = Color.white;
        playerMaterials[1].color = Color.white;
        playerMaterials[2].color = Color.white;
    }
}
