using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPlayerMoveSpear : MonoBehaviour
{
    [Header("移動のスピード")]
    [SerializeField] float _moveSpeed = 1f;
    [Header("攻撃のアニメーション")]
    [SerializeField] Animator spearAnim;
    [Header("攻撃のインターバル")]
    float _timer = 0;
    [SerializeField] float _intrval = 1f;
    [Header("破壊された時のエフェクトと音")]
    [SerializeField] GameObject _effect;
    [SerializeField] GameObject _prefab;
    WeaponsHP _damage;
    bool _isAttackOnStart = true;
    WeaponsWarTimeManager _weaponsWarTimeManager;
    public static bool IsSpearAlive = true;
    AudioSource _audioSource;
    [SerializeField] GameObject _audioPrefab;
    void Start()
    {
        _weaponsWarTimeManager = GameObject.Find("Time").GetComponent<WeaponsWarTimeManager>();
        _damage = GetComponentInChildren<WeaponsHP>();
        _audioSource = GetComponentInChildren<AudioSource>();
        if (_isAttackOnStart)
        {
            _timer = _intrval;
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && _timer > _intrval && IsSpearAlive)
        {
            _timer = 0;
            spearAnim.Play("SpearAttackAnim");
            _audioSource.Play();
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * _moveSpeed, 0f, 0f);
        transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * Time.deltaTime * _moveSpeed, 0f);
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.rotation = rotation;
        if (_damage._hp <= 0)
        {
            _damage.IsAlive = false;
            _weaponsWarTimeManager.IsSurvive = false;
            IsSpearAlive = false;
            Instantiate(_effect, transform.position, Quaternion.identity);
            Instantiate(_prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponsHP HP = collision.gameObject.GetComponent<WeaponsHP>();
        if (HP != null)
        {
            if (HP.IsInvincible)
            {
                _damage.Damage(1);
                Instantiate(_audioPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    //public void D(int d) => _hp = IsInvincible ? _hp : _hp - d;
}