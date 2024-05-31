using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ObjectCreate : MonoBehaviour

{
    
    [SerializeField] GameObject _prefubs;
    [SerializeField] List<Transform> _transforms = new List<Transform>();
    [SerializeField] float spawnrange = 1f;
    // Start is called before the first frame update
    void Spawn()
    {
        float distance  = Vector2.Distance(_transforms[0].position, _transforms[1].position);
        float randomDistance = Random.Range(0, distance);
        int randumtransforms = Random.Range(0, _transforms.Count);
        Instantiate(_prefubs, _transforms[0].position + new Vector3(randomDistance,0), Quaternion.identity);
    }

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(nameof(CoolTime));
    }
    IEnumerator CoolTime()
    {
        //Debug.Log("aaaaa");
        yield return new WaitForSeconds(spawnrange);
        Spawn();
        yield return new WaitForSeconds(spawnrange/2);
        Spawn();
        StartCoroutine(nameof(CoolTime));
    }
}
