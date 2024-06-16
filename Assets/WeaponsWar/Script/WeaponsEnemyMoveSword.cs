using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMoveSword : MonoBehaviour
{
    [SerializeField] float _enemyMoveSpeed = 1f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _attackRange;
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    bool _isEnemyMove;
    [SerializeField] float _interval = 2f;
    float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        var roatation = Quaternion.LookRotation( Vector3.forward,_playerTransform.position - transform.position);
        transform.rotation = roatation;
        // Debug.Log($"time{_timer}");
        _timer += Time.deltaTime;
        // ���g�Ƒ���̊p�x���Ƃ�
        float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);

        Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

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
            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
        }
    }

    public void PlayAnim()
    {
        swordAnim.Play("SwordAtackAnim");
        _timer = 0f;

    }
    //    if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange && _isEnemyMove)
    //    {
    //        
    //        //����̕����Ɍ�����
    //        
    //        if (Vector2.Distance(_playerTransform.position, transform.position) >= 2)
    //        {
    //            _isEnemyMove = false;
    //        }
    //    }
    //    //���ꂽ��ړ���؂�ւ���
    //    else if (Vector2.Distance(_playerTransform.position, transform.position) >= _attackRange)
    //    {
    //        if (!_isEnemyMove)
    //        {
    //            transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
    //            _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
    //            _isEnemyMove = true;
    //            Debug.Log($"���ꂽ{_rigidbody.velocity}");
    //        }
    //        else
    //        {
    //            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
    //        }
    //    }

}
