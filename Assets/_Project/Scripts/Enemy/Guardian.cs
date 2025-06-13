using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : EnemyBase
{
    [SerializeField] private GameObject[] pattuglia; //gli empties che rappresentano il percorso dell'enemy
    [SerializeField] private float _imprecisione = 0.25f; // i transform difficilmente saranno ==
    public float _maxRange = 8f;


    private EnemyGun _enemyShooter;
    private int _currentDir = 0;

    //[SerializeField] private GameObject _spawnPoint;  


    public override void Move()
    {
        _mover.UpdateDirection(pattuglia[_currentDir].transform.position - transform.position);
        if (Vector2.Distance(transform.position, pattuglia[_currentDir].transform.position) < _imprecisione)
        {
            _currentDir++;
            if (_currentDir == pattuglia.Length)
            {
                _currentDir = 0;
            }
        }
    }

    public override void Attack(){}

    public override void Start()
    {
        base.Start();
    }
}
