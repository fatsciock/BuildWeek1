using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TopDownMover2D _mover;
    private Animator _animator;

    void Start()
    {
        _mover = GetComponent<TopDownMover2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        _mover.UpdateDirection(dir);

        if (dir != Vector2.zero)
        {
            _animator.SetBool("isWalk", true);
            _animator.SetFloat("xDir", dir.x);
            _animator.SetFloat("yDir", dir.y);
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }


    }
}
