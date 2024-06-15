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
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自身と相手の角度をとる
        float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);
        //　
        Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        // 指定した距離より短くなったら攻撃する
        if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange && _isEnemyMove)
        {
            swordAnim.Play("SwordAtackAnim");
            //相手の方向に向かう
            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
            if (Vector2.Distance(_playerTransform.position, transform.position) >= 2)
            {
                _isEnemyMove = false;
            }
        }
        //離れたら移動を切り替える
        else if (Vector2.Distance(_playerTransform.position, transform.position) >= _attackRange)
        {
            if (!_isEnemyMove)
            {
                transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
                _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
                _isEnemyMove = true;
                Debug.Log($"離れた{_rigidbody.velocity}");
            }
            else
            {
                _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
            }
        }
    }
}
