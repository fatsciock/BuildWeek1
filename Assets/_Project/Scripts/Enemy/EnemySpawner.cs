using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private float _activationRange = 15f;
    [SerializeField] private int _maxEnemies = 7;

    private float _lastSpawnTime;
    private Transform _player;
    private List<GameObject> _spawnedEnemies = new();

    void Start()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            _player = player.transform;
        }
    }

    void Update()
    {
        if (_player == null) return;

        float distance = Vector2.Distance(transform.position, _player.position);
        if (distance > _activationRange) return;

        _spawnedEnemies.RemoveAll(e => e == null);

        if (Time.time - _lastSpawnTime >= _spawnInterval && _spawnedEnemies.Count < _maxEnemies)
        {
            GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            _spawnedEnemies.Add(enemy);
            _lastSpawnTime = Time.time;
        }
    }
}
