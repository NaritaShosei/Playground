using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _isCheat = false;


    // Start is called before the first frame update
    void Start()
    {
        _isCheat=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isCheat = true;
        }

        if ( _isCheat)
        {
            Debug.Log(_isCheat);

        }
        if (!_isCheat) 
        {
            Debug.Log(_isCheat);
        }
    }
}
