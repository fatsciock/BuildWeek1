using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : EnemyBase
{
    private float _changeDirectionTime = 0f;
    private float _moveDuration = 1f;
    private float _pauseDuration = 1f;
    private bool _isMoving = true;

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        if(Time.time > _changeDirectionTime)
        {
            _isMoving = !_isMoving;
            if (_isMoving)
            {
                Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                _mover.UpdateDirection(dir);
                _changeDirectionTime = _moveDuration + Time.time;
            }
            else
            {
                _mover.UpdateDirection(Vector2.zero);
                _changeDirectionTime = _pauseDuration + Time.time;
            }
        }
    }

}
