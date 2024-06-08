using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ObjectCreate : MonoBehaviour

{
    [Header("�����������I�u�W�F�N�g")]
    [SerializeField] GameObject _prefubs;
    [Header("�w�肵�����W�ƍ��W�̊ԂŐ���")]
    [SerializeField] List<Transform> _transforms = new List<Transform>();
    [Header("�����̃N�[���^�C��")]
    [SerializeField] float spawnrange = 1f;
    [SerializeField] float spawnrange2 = 1f;
    [SerializeField] float spawnrange3 = 1f;
    // Start is called before the first frame update
    void Spawn()
    {
        float distance  = Vector2.Distance(_transforms[0].position, _transforms[1].position);
        float randomDistance = Random.Range(0, distance);
        // int randumtransforms = Random.Range(0, _transforms.Count);
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
        yield return new WaitForSeconds(spawnrange2);
        Spawn();
        yield return new WaitForSeconds(spawnrange3);
        Spawn();
        StartCoroutine(nameof(CoolTime));
    }
}
