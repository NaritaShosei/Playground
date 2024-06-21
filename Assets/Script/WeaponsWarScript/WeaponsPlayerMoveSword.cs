using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPlayerMoveSword : MonoBehaviour
{

    [SerializeField] float _move = 1f;
    [SerializeField] Animator swordAnim;
    [SerializeField] float _timer = 0;
    [SerializeField] float _intrval = 1f;
    WeaponsHP _damage;
    bool _isAttackOnStart = true;
    WeaponsWarTimeManager _weaponsWarTimeManager;
    SceneChangeManager _sceneChangeManager;
    public bool IsSwordAlive = true;
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
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && _timer > _intrval && IsSwordAlive)
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
            IsSwordAlive = false;
            //Invoke("SceneChange", 1.2f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponsHP HP = collision.gameObject.GetComponent<WeaponsHP>();
        if (HP != null)
        {
            if (HP.IsInvincible || HP.IsInvincible)
            {
                _damage.Damage(1);
            }
        }
    }
    //public void D(int d) => _hp = IsInvincible ? _hp : _hp - d;
}
