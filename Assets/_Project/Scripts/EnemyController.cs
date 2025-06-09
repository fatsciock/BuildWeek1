using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private TopDownMover2D _mover;

    void Start()
    {
        _mover = GetComponent<TopDownMover2D>();

        if (_target == null)
        {
            PlayerController player = FindAnyObjectByType<PlayerController>(FindObjectsInactive.Include);
            _target = player.transform;
        }
    }

    void Update()
    {
        if (_target == null) return;

        _mover.UpdateDirection(_target.position - transform.position);
    }
}
