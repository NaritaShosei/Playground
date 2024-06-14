using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsHP : MonoBehaviour
{
    [SerializeField] float _hp = 5f;
    public bool IsInvincible;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Damage(float damage)
    {
        if (!IsInvincible)
        {
            _hp -= damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
