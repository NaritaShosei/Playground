using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] GameObject _backGround1;
    [SerializeField] GameObject _backGround2;
    [SerializeField] GameObject _backGround3;
    [SerializeField] float _backGroundSpeed = 1.0f;
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
        /*if (_backGround2.transform.position.y < _endVec.y)
        {
            _backGround2.transform.position = _startVec;
        }
        if (_backGround3.transform.position.y < _endVec.y)
        {
            _backGround3.transform.position = _startVec;
        }*/


    }
    private void FixedUpdate()
    {
        _backGround1.transform.position += Vector3.down * _backGroundSpeed;
        /*_backGround2.transform.position += Vector3.down * _backGroundSpeed;
        _backGround3.transform.position += Vector3.down * _backGroundSpeed;*/
    }

}
