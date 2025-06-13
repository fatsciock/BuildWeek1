using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private AbstractGun _shooter;
    [SerializeField] public LifeController _lifeController {  get; private set; }
    [SerializeField] protected TopDownMover2D _mover {get; set;}
    [SerializeField] protected GameObject _player;

    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected Collider2D _collider;

    [SerializeField] protected int dmg;
    //[SerializeField] private bool _canShoot;
    [SerializeField] protected int _dropRate;

    protected Vector2 direction;
    protected Vector2 position;

    [SerializeField] GameObject[] _weapons;

    public virtual void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null) Debug.Log("Manca il player!");

        _collider = GetComponent<Collider2D>();
        if (_collider == null) Debug.Log("Manca il collider!");

        _mover = GetComponent<TopDownMover2D>();
        if (_mover == null) Debug.Log("Manca il Mover!");

        _lifeController = GetComponent<LifeController>();
        if (_lifeController == null) Debug.Log("Mancano gli hp!");
    }

    public virtual void FixedUpdate()
    {
        Move();
    }

    public abstract void Attack();

    public abstract void Move();

    public void DropWeapon()
    {
        int chance = Random.Range(0, 101);
        if (_dropRate >= chance)
        {
            Vector2 pos = transform.position;
            int chooseRandom = Random.Range(0, (_weapons.Length));
            Instantiate(_weapons[chooseRandom], new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        _player.GetComponent<LifeController>().AddHp(-_dmg);
    //    }

    //}


    //void Awake()
    //{
    //    _player = GameObject.FindWithTag("Player");
    //}


}
