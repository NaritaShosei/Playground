using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPlayerMoveSword : MonoBehaviour
{

    [SerializeField] float _move = 1f;
    [SerializeField] Animator swordAnim;
    [SerializeField] float _timer = 0;
    [SerializeField] float _intrval = 1f;
    [SerializeField] GameObject _enemySword;
    [SerializeField] GameObject _enemySpear;
    WeaponsHP _damage;
    bool _isAttackOnStart = true;
    WeaponsWarTimeManager _weaponsWarTimeManager;
    SceneChangeManager _sceneChangeManager;
    void Start()
    {
        _weaponsWarTimeManager = GameObject.Find("Time").GetComponent<WeaponsWarTimeManager>();
        _sceneChangeManager = GameObject.Find("SceneChange").GetComponent<SceneChangeManager>();
        _damage = GetComponentInChildren<WeaponsHP>();

        if (_isAttackOnStart)
        {
            _timer = _intrval;
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && _timer > _intrval)
        {
            _timer = 0;
            swordAnim.Play("SwordAtackAnim");
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * _move, 0f, 0f);
        transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * Time.deltaTime * _move, 0f);
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.rotation = rotation;
        if (_damage._hp <= 0)
        {
            _damage.IsAlive = false;
            Destroy(gameObject, 1);
            _weaponsWarTimeManager.IsSurvive = false;
            //Invoke("SceneChange", 1.2f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //WeaponsHP HP = _enemySword.GetComponentInChildren<WeaponsHP>();
        //WeaponsHP HP2 = _enemySpear.GetComponentInChildren<WeaponsHP>();
        WeaponsHP HP3 = collision.gameObject.GetComponent<WeaponsHP>();
        if (HP3 != null)
        {
            if (HP3.IsInvincible || HP3.IsInvincible)
            {
                _damage.Damage(1);
            }
        }
    }
    private void OnDestroy()
    {
        _sceneChangeManager.Result();
    }
    //public void D(int d) => _hp = IsInvincible ? _hp : _hp - d;
}
