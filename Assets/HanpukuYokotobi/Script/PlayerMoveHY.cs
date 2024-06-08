using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveHY : MonoBehaviour
{
    [Header("���������т̕�")]
    [SerializeField] float _moveSize = 1f;
    [Header("���������т̌��E�l")]
    [SerializeField] public float _moveRange = 1f;
    public int _moveCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -_moveRange)
            {
                if (_moveCount == 1)
                {
                    transform.position += transform.right * -_moveSize;
                    transform.localScale = new Vector3(-0.61f, 0.61f, 0.61f);
                }
            }
        }
        if (this.transform.position.x == _moveRange)
        {
            _moveCount = 1;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.transform.position.x < _moveRange)
            {
                if (_moveCount == 0)
                {
                    transform.position += transform.right * _moveSize;
                    transform.localScale = new Vector3(0.61f, 0.61f, 0.61f);
                }
            }
        }
        if (this.transform.position.x == -_moveRange)
        {
            _moveCount = 0;
        }
    }
}
