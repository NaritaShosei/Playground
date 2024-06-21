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
    [SerializeField] float _interval = 2f;
    float _timer = 0f;
    WeaponsHP damage;
    EnemyGenerator EnemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponentInChildren<WeaponsHP>();
        _rigidbody = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("PlayerSword");
        EnemyGenerator = GameObject.Find("Main Camera").GetComponent<EnemyGenerator>();

        if (player.TryGetComponent<Transform>(out var transform))
        {
            _playerTransform = transform;
        }
        if (Vector2.Distance(_playerTransform.position, this.transform.position) < 5)
        {
            Debug.Log("”j‰ó‚³‚ê‚½");
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

            Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));


            // Debug.Log($"time{_timer}");
            // Ž©g‚Æ‘ŠŽè‚ÌŠp“x‚ð‚Æ‚é


            // Žw’è‚µ‚½‹——£‚æ‚è’Z‚­‚È‚Á‚½‚çUŒ‚‚·‚é
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
        if (_playerTransform == null) { return; }
        WeaponsHP HP = _playerTransform.GetComponentInChildren<WeaponsHP>();
        if (HP.IsInvincible)
        {
            damage.Damage(1);
        }
    }
    //    if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange && _isEnemyMove)
    //    {
    //        
    //        //‘ŠŽè‚Ì•ûŒü‚ÉŒü‚©‚¤
    //        
    //        if (Vector2.Distance(_playerTransform.position, transform.position) >= 2)
    //        {
    //            _isEnemyMove = false;
    //        }
    //    }
    //    //—£‚ê‚½‚çˆÚ“®‚ðØ‚è‘Ö‚¦‚é
    //    else if (Vector2.Distance(_playerTransform.position, transform.position) >= _attackRange)
    //    {
    //        if (!_isEnemyMove)
    //        {
    //            transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
    //            _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
    //            _isEnemyMove = true;
    //            Debug.Log($"—£‚ê‚½{_rigidbody.velocity}");
    //        }
    //        else
    //        {
    //            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
    //        }
    //    }

}
