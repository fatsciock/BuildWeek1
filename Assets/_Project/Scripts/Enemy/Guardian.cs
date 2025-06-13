using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : EnemyBase
{
    [SerializeField] private GameObject[] pattuglia; //gli empties che rappresentano il percorso dell'enemy
    [SerializeField] private float _imprecisione = 0.25f; // i transform difficilmente saranno ==


    private EnemyShooter _enemyShooter;
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

    public override void Attack()
    {
        _enemyShooter.EvaluateSpawnPoint();
        _enemyShooter.TryShoot(_enemyShooter.pos,  _player.transform.position - _enemyShooter.pos  );            
    }

    public override void Start()
    {
        base.Start();
        _enemyShooter = GetComponent<EnemyShooter>();
        if (_enemyShooter == null) Debug.Log("Manca lo shooter!");
    }

    public override void Update()
    {
        base.Update();
        if (Vector2.Distance(_player.transform.position, transform.position) < _enemyShooter._maxRange)
        {
            Attack();
        }
    }
}
