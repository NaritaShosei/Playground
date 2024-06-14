using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    [Header("�΂��������Ă���X�s�[�h")]
    [SerializeField] float _rockSpeed = 1f;
    [Header("�΂��j�󂳂�鎞��")]
    [SerializeField] float _destroyTime = 1f;
    [Header("�΂��j�󂳂��Ƃ��̃G�t�F�N�g")]
    [SerializeField] GameObject _effectPrefub;
    AudioSource _bgm;
    public Rigidbody2D _rockrb;
    bool _isCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        _bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        _rockrb = GetComponent<Rigidbody2D>();
        _rockrb.velocity = new Vector2(0, -_rockSpeed);
        Invoke("Destroy", _destroyTime);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rockrb.velocity = new Vector2(0,-_rockSpeed * 1.5f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rockrb.velocity = new Vector2(0, -_rockSpeed );
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isCollision)
        {
            GameObject effect = Instantiate(_effectPrefub, this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
  


}
