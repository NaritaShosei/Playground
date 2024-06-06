using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveHY : MonoBehaviour
{
    [Header("”½•œ‰¡’µ‚Ñ‚Ì•")]
    [SerializeField] float _moveSize = 1f;
    [Header("”½•œ‰¡’µ‚Ñ‚ÌŒÀŠE’l")]
    [SerializeField] float _moveRange = 1f;
    public int _moveCount = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && this.transform.position.x > -_moveRange || Input.GetKeyDown(KeyCode.LeftArrow) && this.transform.position.x > -_moveRange)
        {
            if (_moveCount == 1)
            {
                transform.position += transform.right * -_moveSize;
            }
        }
            if (this.transform.position.x == _moveRange)
            {
                _moveCount = 1;
            }
        if (Input.GetKeyDown(KeyCode.D) && this.transform.position.x < _moveRange || Input.GetKeyDown(KeyCode.RightArrow) && this.transform.position.x < _moveRange)
        {
            if (_moveCount == 0) 
            {
                transform.position += transform.right * _moveSize;
            }
        }
            if (this.transform.position.x == -_moveRange)
            {
                _moveCount = 0;
            }
    }
}
