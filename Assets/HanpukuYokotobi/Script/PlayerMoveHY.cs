using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveHY : MonoBehaviour
{
    [Header("îΩïúâ°íµÇ—ÇÃïù")]
    [SerializeField] float _moveSize = 1f;
    [Header("îΩïúâ°íµÇ—ÇÃå¿äEíl")]
    [SerializeField] public float _moveRange = 1f;
    public int _moveCount = 0;
    TimeManager _timeManager;
    ScoreCount _scoreCount;
    //bool check = true;
    AudioSource _audioSource;
    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _timeManager = FindAnyObjectByType<TimeManager>();
        _scoreCount = FindAnyObjectByType<ScoreCount>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _timeManager.IsInGame == true)
        {
            //if (this.transform.position.x > -_moveRange)
            //{
               // if (_moveCount == 1)
              //  {
                    // transform.position += transform.right * -_moveSize;
                    _rigidbody2D.AddForce(Vector2.left * _moveSize, ForceMode2D.Force);
                    transform.localScale = new Vector3(-0.61f, 0.61f, 0.61f);
               // }
           // }
        }
        //if (this.transform.position.x == _moveRange)
        //{
        //    _moveCount = 1;
        //    check = true;
        //}

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _timeManager.IsInGame == true)
        {
            //if (this.transform.position.x < _moveRange)
            //{

                //if (_moveCount == 0)
                //{
                    // transform.position += transform.right * _moveSize;
                    _rigidbody2D.AddForce(Vector2.right * _moveSize, ForceMode2D.Force);
                    transform.localScale = new Vector3(0.61f, 0.61f, 0.61f);
               // }
           // }
        }
        //if (this.transform.position.x == -_moveRange && check)
        //{
        //    _moveCount = 0;
        //    _scoreCount.GetCount();
        //    check = false;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            _moveCount = 1;
        }
        if (collision.gameObject.tag == "Left" && _moveCount == 1)
        {
            _moveCount = 0;
            _scoreCount.GetCount();
        }
    }

}
