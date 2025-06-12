using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform _spawnPoint;
    [SerializeField] protected float _shotInterval = 1f;
    [SerializeField] protected float _projectileSpeed = 5f;
    [SerializeField] protected int _damage = 1;

    private float _lastShotTime;

    protected virtual void Update()
    {
        if (Time.time - _lastShotTime >= _shotInterval)
        {
            Shoot();
            _lastShotTime = Time.time;
        }
    }

    protected abstract void Shoot();

    public virtual void LevelUp()
    {
        _damage += 1;
        _shotInterval *= 0.9f;
        _projectileSpeed += 1f;
    }
}
