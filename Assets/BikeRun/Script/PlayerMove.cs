using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("�f�t�H���g�̃X�s�[�h")]
    [SerializeField] float _moveSpeed = 1f;
    [Header("�v���C���[�̈ړ����E���W")]
    [SerializeField] float _maxRange = 1f;
    [Header("MoveSpeed�Ɠ����l������")]
    [SerializeField] float SpeedUp = 1f ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             SpeedUp = _moveSpeed*2;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpeedUp = _moveSpeed;
        }
        if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -_maxRange || Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x >= -_maxRange )
        {
            transform.position += transform.right * -SpeedUp * Time.deltaTime;
        }
        //else if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x >= -_maxRange)
        //{
        //    transform.position += transform.right * -SpeedUp * Time.deltaTime;
        //}
        if (Input.GetKey(KeyCode.D) && this.transform.position.x <= _maxRange || Input.GetKey(KeyCode.RightArrow) && this.transform.position.x <= _maxRange)
        {
            transform.position += transform.right * SpeedUp * Time.deltaTime;
        }
        //else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x <= _maxRange)
        //{
        //    transform.position += transform.right * SpeedUp * Time.deltaTime;
        //} 
        
    }
}
