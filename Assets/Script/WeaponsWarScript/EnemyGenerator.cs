using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _enemys;
    [SerializeField] Transform[] _spawnPrefab1;
    [SerializeField] Transform[] _spawnPrefab2;
    [SerializeField] Transform[] _spawnPrefab3;
    [SerializeField] Transform[] _spawnPrefab4;
    int _enemyCount = 0;
    [SerializeField] float _spawnInterval1;
    [SerializeField] float _spawnInterval2;
    [SerializeField] float _spawnInterval3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CoolTime");
    }
    void Spawn()
    {
        float dis = Vector2.Distance(_spawnPrefab1[0].position, _spawnPrefab1[1].position);
        float randomdis = Random.Range(0, dis);
        Instantiate(_enemys[_enemyCount], _spawnPrefab1[0].position + new Vector3(randomdis, 0), Quaternion.identity);
        _enemyCount++;
        if (_enemyCount >= _enemys.Length)
        {
            _enemyCount = 0;
        }
    }
    void Spawn2()
    {
        float dis2 = Vector2.Distance(_spawnPrefab2[0].position, _spawnPrefab2[1].position);
        float randomdis2 = Random.Range(0, dis2);
        Instantiate(_enemys[_enemyCount], _spawnPrefab1[0].position + new Vector3(0,randomdis2), Quaternion.identity);
        _enemyCount++;
        if (_enemyCount >= _enemys.Length)
        {
            _enemyCount = 0;
        }
    }
    // Update is called once per frame
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(_spawnInterval1);
        Spawn();
        yield return new WaitForSeconds(_spawnInterval2);
        Spawn2();
        StartCoroutine("CoolTime");
    }
    void Update()
    {
        
    }
}
