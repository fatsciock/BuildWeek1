using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShooter : AbstractShooter
{

    [SerializeField] public float _maxRange;
    public Vector3 pos { get; set; }   

    public void EvaluateSpawnPoint()
    {
        pos = _spawnLocation.transform.position;
    }
}
