using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMove : MonoBehaviour
{
    [SerializeField] float _enemyMoveSpeed = 1f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _attackRange;
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    bool _isEnemyMove;
    [SerializeField] float _interval = 2f;
    float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"time{_timer}");
        _timer += Time.deltaTime;
        // é©êgÇ∆ëäéËÇÃäpìxÇÇ∆ÇÈ
        float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);

        Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
        // éwíËÇµÇΩãóó£ÇÊÇËíZÇ≠Ç»Ç¡ÇΩÇÁçUåÇÇ∑ÇÈ
        if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange)
        {
            if (_timer > _interval)
            {

                PlayAnim();
            }
        }
    }

    public void PlayAnim()
    {
        swordAnim.Play("SwordAtackAnim");
        _timer = 0f;

    }
    //    if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange && _isEnemyMove)
    //    {
    //        
    //        //ëäéËÇÃï˚å¸Ç…å¸Ç©Ç§
    //        
    //        if (Vector2.Distance(_playerTransform.position, transform.position) >= 2)
    //        {
    //            _isEnemyMove = false;
    //        }
    //    }
    //    //ó£ÇÍÇΩÇÁà⁄ìÆÇêÿÇËë÷Ç¶ÇÈ
    //    else if (Vector2.Distance(_playerTransform.position, transform.position) >= _attackRange)
    //    {
    //        if (!_isEnemyMove)
    //        {
    //            transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
    //            _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
    //            _isEnemyMove = true;
    //            Debug.Log($"ó£ÇÍÇΩ{_rigidbody.velocity}");
    //        }
    //        else
    //        {
    //            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
    //        }
    //    }

}
