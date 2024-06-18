using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMoveSword : MonoBehaviour
{
    [SerializeField] float _enemyMoveSpeed = 1f;
    Transform _playerTransform;
    [SerializeField] float _attackRange;
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    bool _isEnemyMove;
    [SerializeField] float _interval = 2f;
    float _timer = 0f;
    WeaponsHP damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponentInChildren<WeaponsHP>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _timer = _interval;
        _playerTransform = GameObject.Find("PlayerSword").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform != null)
        {
            var roatation = Quaternion.LookRotation(Vector3.forward, _playerTransform.position - transform.position);
            transform.rotation = roatation;
            float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);

            Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));


            // Debug.Log($"time{_timer}");
            _timer += Time.deltaTime;
            // 自身と相手の角度をとる


            // 指定した距離より短くなったら攻撃する
            if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange)
            {
                if (Vector2.Distance(_playerTransform.position, transform.position) <= 0.2f)
                {
                    _rigidbody.velocity = new Vector2(0, 0);
                }
                if (_timer > _interval)
                {

                    PlayAnim();
                }
            }
            else
            {
                _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
            }
        }
        if (_playerTransform == null)
        {
            Quaternion myroa = transform.rotation;
            transform.rotation = myroa;
            _rigidbody.velocity = new Vector2(0, 0);
        }
        if (damage._hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAnim()
    {
        swordAnim.Play("SwordAtackAnim");
        _timer = 0f;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponsHP HP = _playerTransform.GetComponentInChildren<WeaponsHP>();
        if (HP.IsInvincible)
        {
            damage.Damage(1);
        }
    }
    //    if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange && _isEnemyMove)
    //    {
    //        
    //        //相手の方向に向かう
    //        
    //        if (Vector2.Distance(_playerTransform.position, transform.position) >= 2)
    //        {
    //            _isEnemyMove = false;
    //        }
    //    }
    //    //離れたら移動を切り替える
    //    else if (Vector2.Distance(_playerTransform.position, transform.position) >= _attackRange)
    //    {
    //        if (!_isEnemyMove)
    //        {
    //            transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
    //            _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
    //            _isEnemyMove = true;
    //            Debug.Log($"離れた{_rigidbody.velocity}");
    //        }
    //        else
    //        {
    //            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
    //        }
    //    }

}
