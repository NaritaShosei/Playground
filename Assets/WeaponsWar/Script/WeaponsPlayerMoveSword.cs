using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPlayerMoveSword : MonoBehaviour
{
    
    [SerializeField] float _move = 1f;
    [SerializeField] Animator swordAnim;
    [SerializeField] float _timer =0;
    [SerializeField] float _intrval = 1f;
    bool _isAttackOnStart = true;
    void Start()
    {
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

    }

    //public void D(int d) => _hp = IsInvincible ? _hp : _hp - d;
}
