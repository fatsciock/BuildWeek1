using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] public float _shotInterval { get; private set; }
    [SerializeField] public float _maxRange { get; private set; }

    private float _lastShotTime = 0;


    public virtual bool CanShoot()
    {
        
        return Time.time - _lastShotTime >= _shotInterval;
    }

    public void Shoot(Vector3 position, Vector3 direction)
    {
        _lastShotTime = Time.time;

        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(position, direction);
    }

    //public void TryShoot(Vector3 position, Vector3 direction)
    //{
    //    if (!CanShoot()) return;

    //    Shoot(position, direction);
    //}


}
