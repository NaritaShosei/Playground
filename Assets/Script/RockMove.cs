using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    [SerializeField] float _rockSpeed = 1f;
    [SerializeField] float _destroyTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D _rockrb = GetComponent<Rigidbody2D>();
        _rockrb.velocity = new Vector2(0,-_rockSpeed);
        Invoke("Destroy",_destroyTime);
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
