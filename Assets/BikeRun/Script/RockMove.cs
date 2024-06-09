using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    [Header("石が向かってくるスピード")]
    [SerializeField] float _rockSpeed = 1f;
    [Header("石が破壊される時間")]
    [SerializeField] float _destroyTime = 1f;
    [Header("石が破壊されるときのエフェクト")]
    [SerializeField] GameObject _effectPrefub;
    AudioSource _bgm;
    bool _isCollision = true;
    // Start is called before the first frame update
    void Start()
    {
        _bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        Rigidbody2D _rockrb = GetComponent<Rigidbody2D>();
        _rockrb.velocity = new Vector2(0, -_rockSpeed);
        Invoke("Destroy", _destroyTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && _isCollision)
        {
            GameObject effect = Instantiate(_effectPrefub, this.transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            //_bgm.volume = 0.01f;
            //_isCollision = false;
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
            
    //    }
    //}
    private void Destroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    //private void Update()
    //{
    //    if (_isCollision == false)
    //    {
    //        Invoke("VolumeUp", 0.5f);
    //    }

    //}
    //public void VolumeUp()
    //{
    //    _bgm.volume = 0.305f;
    //}


}
