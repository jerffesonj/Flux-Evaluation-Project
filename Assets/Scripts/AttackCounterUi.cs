using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackCounterUi : MonoBehaviour
{
    int punchCounter;
    int kickCounter;

    public TMP_Text punchCounterText;
    public TMP_Text kickCounterText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTexts();
        PlayerAttack.OnPunchUsed += AddPunchCounter;
        PlayerAttack.OnKickUsed += AddKickCounter;
    }
    private void OnDisable()
    {
        PlayerAttack.OnPunchUsed -= AddPunchCounter;
        PlayerAttack.OnKickUsed -= AddKickCounter;
    }
   
    void AddPunchCounter()
    {
        punchCounter += 1;

        UpdateTexts();
    }
    void AddKickCounter()
    {
        kickCounter += 1;

        UpdateTexts();
    }
    void UpdateTexts()
    {
        punchCounterText.text = punchCounter.ToString();
        kickCounterText.text = kickCounter.ToString();
    }
}
