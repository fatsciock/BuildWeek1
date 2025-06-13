using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun3 : GunBase
{
    [SerializeField] private int _shotsPerBurst = 3;
    [SerializeField] private float _minAngle = 0f;
    [SerializeField] private float _maxAngle = 360f;

    protected override void Shoot()
    {
        for (int i = 0; i < _shotsPerBurst; i++)
        {
            float randomAngle = Random.Range(_minAngle, _maxAngle);
            float rad = randomAngle * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f);

            Fire(direction);
        }
    }

    private void Fire(Vector3 direction)
    {
        Bullet b = Instantiate(_bulletPrefab);
        b.Shoot(_spawnPoint.position, direction);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        _damage += 1;
    }
}

