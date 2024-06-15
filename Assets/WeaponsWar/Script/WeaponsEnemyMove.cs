using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsEnemyMove : MonoBehaviour
{
    [SerializeField] float _enemyMoveSpeed = 1f;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _attackRange;
    [SerializeField] Animator swordAnim;
    Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(_playerTransform.position.y - transform.position.y, _playerTransform.position.x - transform.position.x);
        Vector2 Axis = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        if (Vector2.Distance(_playerTransform.position, transform.position) <= _attackRange)
        {
            swordAnim.Play("SwordAtackAnim");
            _rigidbody.velocity = new Vector2(Axis.x * _enemyMoveSpeed, Axis.y * _enemyMoveSpeed);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + Axis.x * _enemyMoveSpeed * Time.deltaTime, transform.position.y + Axis.y * _enemyMoveSpeed * Time.deltaTime);
            _rigidbody.velocity = new Vector2(Axis.x * 0, Axis.y * 0);
        }
    }
}
