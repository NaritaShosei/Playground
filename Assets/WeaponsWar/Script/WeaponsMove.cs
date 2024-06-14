using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsMove : MonoBehaviour
{
    
    [SerializeField] float _move = 1f;
    [SerializeField] Animator swordAnim;
    
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swordAnim.Play("SwordAtackAnim");
        }
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * _move, 0f, 0f);
        transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * Time.deltaTime * _move, 0f);
        var pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    


    //public void D(int d) => _hp = IsInvincible ? _hp : _hp - d;
}
