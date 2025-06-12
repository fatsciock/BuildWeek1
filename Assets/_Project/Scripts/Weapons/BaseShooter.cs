using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShooter : AbstractShooter
{
    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        TopDownMover2D mover = GetComponentInParent<TopDownMover2D>();
        if (mover == null || !mover.enabled)
        {
            TryShoot(_spawnPoint.position, _spawnPoint.right);
        }
        else
        {
            Debug.Log($"Sparo verso: {mover.LastDirection}");
            TryShoot(_spawnPoint.position, mover.LastDirection);
        }
    }
}
