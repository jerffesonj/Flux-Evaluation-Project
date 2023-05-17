using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackTrigger;
    private int attackIndex;

    private Animator _animator;
    private bool _hasAnimator;
    private StarterAssetsInputs _input;
    private ThirdPersonController _playerController;

    private static readonly int Punch = Animator.StringToHash("Punch");
    private static readonly int Kick = Animator.StringToHash("Kick");

    public int AttackIndex { get => attackIndex; }

    public delegate void OnAttack();
    public static event OnAttack OnPunchUsed;
    public static event OnAttack OnKickUsed;

    void Start()
    {
        _hasAnimator = TryGetComponent(out _animator);
        _input = GetComponent<StarterAssetsInputs>();
        _playerController = GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public bool IsPlayingAttackAnimation()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Punch") || _animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
            return true;
        return false;
    }

    private void Attack()
    {
        if (!_playerController.Grounded || _input.sprint || IsPlayingAttackAnimation())
        {
            _input.buttonX = false;
            _input.buttonY = false;

            return;
        }

        if (_input.buttonX)
        {
            _input.buttonX = false;
            _animator.SetTrigger(Punch);
            OnPunchUsed?.Invoke();
            StartCoroutine(ActivateAttackTrigger());
            attackIndex = 0;

        }
        if (_input.buttonY)
        {
            _input.buttonY = false;
            _animator.SetTrigger(Kick);
            OnKickUsed?.Invoke();
            StartCoroutine(ActivateAttackTrigger());
            attackIndex = 1;
        }
    }

    IEnumerator ActivateAttackTrigger()
    {
        attackTrigger.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        attackTrigger.SetActive(false);
    }
}
