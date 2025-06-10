using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private AbstractShooter _shooter;
    [SerializeField] private LifeController _lifeController;
    //[SerializeField] private GameObject _player;

    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected Collider2D _collider;

    [SerializeField] protected float speed;
    [SerializeField] protected int dmg;
    //[SerializeField] private bool _canShoot;
    [SerializeField] protected int _dropRate;

    protected Vector2 direction;
    protected Vector2 position;

    [SerializeField] GameObject[] _weapons;

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null) Debug.Log("Manca il RigidBody!");

        _collider = GetComponent<Collider2D>();
        if (_collider == null) Debug.Log("Manca il collider!");
    }

    public void DropWeapon()
    {
        int chance = Random.Range(0, 101);
        if (_dropRate <= chance)
        {
            int chooseRandom = Random.Range(0, 4);
            Instantiate(_weapons[chooseRandom]);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        _player.GetComponent<LifeController>().AddHp(-_dmg);
    //    }

    //}

    public virtual void Die()
    {
        DropWeapon();
        Destroy(gameObject);
    }

    public abstract void Attack();
    //void Awake()
    //{
    //    _player = GameObject.FindWithTag("Player");
    //}

    public abstract void Move();        
}
