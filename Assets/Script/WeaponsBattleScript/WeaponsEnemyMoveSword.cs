using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMoveSword : MonoBehaviour
{
    [Header("�ړ��̃X�s�[�h")]
    [SerializeField] float _enemyMoveSpeed = 1f;
    Transform _playerTransform;
    [Header("����ȏ�v���C���[�ɋ߂Â�����U��")]
    [SerializeField] float _attackRange;
    [Header("�U���̃A�j���[�V����")]
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    public static float _interval = 2f;
    float _timer = 0f;
    WeaponsHP damage;
    EnemyGenerator EnemyGenerator;
    AudioSource _audioSource;
    [SerializeField] GameObject _audioPrefab;
    WeaponsHP _hp;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        damage = GetComponentInChildren<WeaponsHP>();
        _rigidbody = GetComponent<Rigidbody2D>();
        //GameObject player = GameObject.Find("PlayerSword");
        EnemyGenerator = GameObject.Find("Main Camera").GetComponent<EnemyGenerator>();
        _audioSource = GetComponentInChildren<AudioSource>();
        if (_playerTransform != null)
        {
            _hp = _playerTransform.GetComponentInChildren<WeaponsHP>();
            if (Vector2.Distance(_playerTransform.position, this.transform.position) < 5)
            {
                Debug.Log("�j�󂳂ꂽ");
                EnemyGenerator._timer = EnemyGenerator._interval;
                Destroy(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if ( _playerTransform != null)
        {
            var roatation = Quaternion.LookRotation(Vector3.forward, _playerTransform.position - transform.position);
            transform.rotation = roatation;
            float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            // �w�肵���������Z���Ȃ�����U������
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
            Instantiate(_audioPrefab, transform.position, Quaternion.identity);
        }
    }

    public void PlayAnim()
    {
        swordAnim.Play("SwordAtackAnim");
        _timer = 0f;
        _audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hp.IsInvincible)
        {
            damage.Damage(1);
        }
    }
}