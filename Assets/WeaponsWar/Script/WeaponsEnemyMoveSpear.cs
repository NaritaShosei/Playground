using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WeaponsEnemyMoveSpear : MonoBehaviour
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

            var rotation = Quaternion.LookRotation(Vector3.forward, _playerTransform.position - transform.position);
            transform.rotation = rotation;
            // Debug.Log($"time{_timer}");
            _timer += Time.deltaTime;
            // é©êgÇ∆ëäéËÇÃäpìxÇÇ∆ÇÈ
            float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);

            Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // éwíËÇµÇΩãóó£ÇÊÇËíZÇ≠Ç»Ç¡ÇΩÇÁçUåÇÇ∑ÇÈ
            if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange)
            {
                _rigidbody.velocity = new Vector2(0, 0);
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
            var roa = Quaternion.identity;
            transform.rotation = roa;
           
        }
        if (damage._hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAnim()
    {
        swordAnim.Play("SpearAttackAnim");
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
}
