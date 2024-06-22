using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMoveSword : MonoBehaviour
{
    [Header("移動のスピード")]
    [SerializeField] float _enemyMoveSpeed = 1f;
    Transform _playerTransform;
    [Header("これ以上プレイヤーに近づいたら攻撃")]
    [SerializeField] float _attackRange;
    [Header("攻撃のアニメーション")]
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    [Header("攻撃するまでの時間")]
    [SerializeField] float _interval = 2f;
    float _timer = 0f;
    WeaponsHP damage;
    EnemyGenerator EnemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponentInChildren<WeaponsHP>();
        _rigidbody = GetComponent<Rigidbody2D>();
        //GameObject player = GameObject.Find("PlayerSword");
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        EnemyGenerator = GameObject.Find("Main Camera").GetComponent<EnemyGenerator>();

        //if (player.TryGetComponent<Transform>(out var transform))
        //{
        //    _playerTransform = transform;
        //}
        if (Vector2.Distance(_playerTransform.position, this.transform.position) < 5)
        {
            Debug.Log("破壊された");
            EnemyGenerator._timer = EnemyGenerator._interval;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_playerTransform != null)
        {
            var roatation = Quaternion.LookRotation(Vector3.forward, _playerTransform.position - transform.position);
            transform.rotation = roatation;
            float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
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
                _rigidbody.velocity = new Vector2(direction.x * _enemyMoveSpeed, direction.y * _enemyMoveSpeed);
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
            ScoreManager._score += ScoreManager._screUp;
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
        if (_playerTransform == null) { return; }
        WeaponsHP HP = _playerTransform.GetComponentInChildren<WeaponsHP>();
        if (HP.IsInvincible)
        {
            damage.Damage(1);
        }
    }
}
