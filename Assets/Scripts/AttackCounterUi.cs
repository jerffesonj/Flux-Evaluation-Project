using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackCounterUi : MonoBehaviour
{
    private int punchCounter;
    private int kickCounter;
    private int totalHitCounter;
    
    public TMP_Text hitCounterText;
    
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
        totalHitCounter = punchCounter + kickCounter;

        hitCounterText.text = totalHitCounter + " Hits";
        hitCounterText.transform.parent.gameObject.SetActive(true);
        StartCoroutine(TurnOffHitCounter());
    }

    IEnumerator TurnOffHitCounter()
    {
        yield return new WaitForSeconds(0.7f);
        hitCounterText.transform.parent.gameObject.SetActive(false);
    }
}
