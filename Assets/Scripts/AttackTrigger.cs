using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    PlayerAttack playerAttack;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DummyScript dummy = other.GetComponent<DummyScript>();
        if (dummy)
        {
            switch (playerAttack.AttackIndex)
            {
                case 0:
                    dummy.SmallHit();
                    break;
                case 1:
                    dummy.BigHit();
                    break;
            }
        }
    }
}
