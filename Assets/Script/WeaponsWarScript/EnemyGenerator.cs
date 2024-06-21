using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("敵のPrefab")]
    [SerializeField] private GameObject[] _enemyObjects;
    [Header("スポーンのインターバル")]
    [SerializeField] public float _interval = 1;
    public float _timer = 0;
    [Header("スポーンの中心点")]
    [SerializeField] private Vector2 _spawnFieldCentorPoint;
    [Header("スポーンの幅")]
    [SerializeField] private Vector2 _spawnField;
    [SerializeField] Transform _playerTransform;
    public SpawnArea spawnArea;
    public enum SpawnArea
    {
        up, down, left, right
    }
    Vector2 spawnPoint;
    private void EnemySpawn()
    {
        System.Array values = System.Enum.GetValues(typeof(SpawnArea));
        int randomIndex = Random.Range(0, values.Length);
        spawnArea = (SpawnArea)values.GetValue(randomIndex);
        if (_playerTransform != null)
        {
            if (spawnArea == SpawnArea.up || spawnArea == SpawnArea.down)
            {
                spawnPoint.x = Random.Range(_playerTransform.position.x - _spawnField.x / 2, _playerTransform.position.x + _spawnField.x / 2);
                spawnPoint.y = Random.Range(_playerTransform.position.y - _spawnField.y / 2, _playerTransform.position.y + _spawnField.y / 2);
            }
            else if (spawnArea == SpawnArea.right || spawnArea == SpawnArea.left)
            {
                spawnPoint.y = Random.Range(_playerTransform.position.y - _spawnField.y / 2, _playerTransform.position.y + _spawnField.y / 2);
                spawnPoint.x = Random.Range(_playerTransform.position.x - _spawnField.x / 2, _playerTransform.position.x + _spawnField.x / 2);
            }
        }
        int randomEnemyIndex = Random.Range(0, _enemyObjects.Length);
        Instantiate(_enemyObjects[randomEnemyIndex], spawnPoint, Quaternion.identity);
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            EnemySpawn();
            _timer = 0;
        }
    }
}
//ほぼ教えてもらったやつ