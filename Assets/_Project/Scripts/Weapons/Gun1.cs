using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun1 : AbstractGun
{
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] private int _angleShoot = 15;

    protected override void Shoot()
    {
        Vector2 baseDirection = (_playerMover == null || !_playerMover.enabled)
        ? Vector2.right
        : _playerMover.LastDirection;

        Fire(baseDirection);
        Fire(RotateDirection(baseDirection, _angleShoot));
        Fire(RotateDirection(baseDirection, -_angleShoot));
    }

    private void Fire(Vector2 direction)
    {
        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(_spawnPoint.position, direction);
    }

    private Vector2 RotateDirection(Vector2 direction, float angle)
    {
        return Quaternion.Euler(0, 0, angle) * direction;
    }

    public override void LevelUp()
    {
        if (_bulletDamage < 10)
        {
            _bulletDamage += 1;
        }
        if (_shotInterval > 0.5f)
        {
            _shotInterval *= 0.9f;
        }
    }
}
