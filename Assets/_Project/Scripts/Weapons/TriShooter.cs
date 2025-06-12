using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriShooter : AbstractShooter
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _angleShoot = 15;

    private void Update()
    {
        TopDownMover2D mover = GetComponentInParent<TopDownMover2D>();
        if (mover == null || !mover.enabled)
        {
            TryShoot(_spawnPoint.position, _spawnPoint.right);
        }
        else
        {
            TryShoot(_spawnPoint.position, mover.LastDirection);
        }
    }

    public override void Shoot(Vector3 position, Vector3 direction)
    {
        _lastShotTime = Time.time;

        Bullet b1 = Instantiate(_bulletPrefab);
        Bullet b2 = Instantiate(_bulletPrefab);
        Bullet b3 = Instantiate(_bulletPrefab);
        b1.Shoot(position, direction);
        b2.Shoot(position, Quaternion.Euler(0, 0, _angleShoot) * direction);
        b3.Shoot(position, Quaternion.Euler(0, 0, -_angleShoot) * direction);
    }
}
