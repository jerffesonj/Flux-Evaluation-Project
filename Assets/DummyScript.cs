using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SmallHit()
    {
        _animator.SetTrigger("Hit");
        _animator.SetInteger("HitIndex", 0);
    }
    public void BigHit()
    {
        _animator.SetTrigger("Hit");
        _animator.SetInteger("HitIndex", 1);
    }
}
