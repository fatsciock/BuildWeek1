using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private AbstractShooter _shooter;
    [SerializeField] private LifeController _lifeController;
    //[SerializeField] private GameObject _player;

    [SerializeField] private int _hp;
    [SerializeField] private float _speed;
    [SerializeField] private int _dmg;
    //[SerializeField] private bool _canShoot;
    [SerializeField] private int _dropRate;

    [SerializeField] GameObject[] _weapons;

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

    public Enemy(float speed, int hp, int dmg)
    {
        
    }
        
}
