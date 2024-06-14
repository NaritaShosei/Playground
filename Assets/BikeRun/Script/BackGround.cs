using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [Header("動かしたい背景")]
    [SerializeField] GameObject _backGround1;
    [Header("背景を動かすスピード")]
    [SerializeField] float _backGroundSpeed = 1.0f;
    [Header("背景をループするときのスタートとエンド")]
    [SerializeField] GameObject _start;
    [SerializeField] GameObject _end;
    Vector2 _startVec;
    Vector2 _endVec;
    void Start()
    {
        _startVec = _start.transform.position;
        _endVec = _end.transform.position;
    }

    void Update()
    {
        if (_backGround1.transform.position.y < _endVec.y)
        {
            _backGround1.transform.position = _startVec;
        }
    }
    
    private void FixedUpdate()
    {
        _backGround1.transform.position += Vector3.down * _backGroundSpeed;
        if (Input.GetKey(KeyCode.Space))
        {
            _backGround1.transform.position += Vector3.down * _backGroundSpeed * 1.5f;
        }
    }

}
