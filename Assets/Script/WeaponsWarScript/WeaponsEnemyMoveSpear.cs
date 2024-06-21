using UnityEngine;

public class WeaponsEnemyMoveSpear : MonoBehaviour
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
            Debug.Log("破壊された");
            EnemyGenerator._timer = EnemyGenerator._interval;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform != null)
        {

            var rotation = Quaternion.LookRotation(Vector3.forward, _playerTransform.position - transform.position);
            transform.rotation = rotation;
            // Debug.Log($"time{_timer}");
            // 自身と相手の角度をとる
            float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);

            Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // 指定した距離より短くなったら攻撃する
            if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange)
            {
                _timer += Time.deltaTime;
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
            Quaternion myroa = transform.rotation;
            transform.rotation = myroa;

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
        if (_playerTransform == null) return;

        WeaponsHP HP = _playerTransform.GetComponentInChildren<WeaponsHP>();
        if (HP.IsInvincible)
        {
            damage.Damage(1);
        }
    }
}
