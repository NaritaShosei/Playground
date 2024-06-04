using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    [Header("�΂��������Ă���X�s�[�h")]
    [SerializeField] float _rockSpeed = 1f;
    [Header("�΂��j�󂳂�鎞��")]
    [SerializeField] float _destroyTime = 1f;
    [Header("�΂��j�󂳂��Ƃ��̃G�t�F�N�g")]
    [SerializeField] GameObject _effectPrefub;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D _rockrb = GetComponent<Rigidbody2D>(); 
        _rockrb.velocity = new Vector2(0,-_rockSpeed);
        Invoke("Destroy", _destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(_effectPrefub, this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
