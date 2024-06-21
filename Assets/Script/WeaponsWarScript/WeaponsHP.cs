using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsHP : MonoBehaviour
{
    [SerializeField] public float _hp = 5f;
    public bool IsInvincible;
    public bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
    }
    public void Damage(float damage)
    {
        if (!IsInvincible)
        {
            if (IsAlive)
            {
                _hp -= damage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
