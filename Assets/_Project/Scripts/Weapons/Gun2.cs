using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2 : GunBase
{
    [SerializeField] private int _bulletCount = 8;

    protected override void Shoot()
    {
        float angleStep = 360f / _bulletCount;
        float currentAngle = 0f;

        for (int i = 0; i < _bulletCount; i++)
        {
            float rad = currentAngle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);

            Fire(direction);
            currentAngle += angleStep;
        }
    }

    private void Fire(Vector3 direction)
    {
        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(_spawnPoint.position, direction);
    }
}
