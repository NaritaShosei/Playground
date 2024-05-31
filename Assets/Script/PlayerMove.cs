using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] float _moveSpeed = 1f;
    
    [SerializeField] float _maxRange = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && this.transform.position.x >= -_maxRange )
        {
            transform.position += transform.right * -_moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x >= -_maxRange)
        {
            transform.position += transform.right * -_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && this.transform.position.x <= _maxRange)
        {
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x <= _maxRange)
        {
            transform.position += transform.right * _moveSpeed * Time.deltaTime;
        } 
        
    }
}
