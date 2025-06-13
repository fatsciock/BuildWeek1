using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : EnemyBase
{
    // [SerializeField] private GameObject _player;
    [SerializeField] private float _force;
    [SerializeField] private float _maxDistance;


    // ABBIAMO GIA' IL TOPDOWN MOVER. DOBBIAMO IMPLEMENTARLO NELLA CLASSE MADRE MOVER!

    //public override void Move()
    //{
    //    direction = _player.transform.position - transform.position;
    //    if (direction != Vector2.zero)
    //    {
    //      position = transform.position;
    //      _rb.MovePosition(position + direction * (speed * Time.fixedDeltaTime));
    //    }
    //}

    public override void Move()
    {
        if (_player != null)
        {            
            direction = _player.transform.position - transform.position;
            if (direction.magnitude < _maxDistance)
            {
                _mover.UpdateDirection(direction);
            }
        }
    }



    public override void Attack()
    {
        //_player.GetComponent<LifeController>().AddHp(-dmg);
        Vector2 _pushDir = ( _player.transform.position - transform.position ).normalized;
        _player.GetComponent<Rigidbody2D>().AddForce(_pushDir * _force, ForceMode2D.Impulse);
        Destroy(gameObject);
    }

    public override void Start()
    {
        base.Start();        
        _player = GameObject.FindWithTag("Player");
        if (_player == null) Debug.LogWarning("In questa scena non è presente alcun giocatore!");
    }  
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();            
        }
    }
}
