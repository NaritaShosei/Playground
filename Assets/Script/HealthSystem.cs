﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [Header("体力")]
    [SerializeField] public int _health = 1;
    [Header("減る体力")]
    [SerializeField] int _stoneDamege = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health <= 0)
        {
            SceneManager.LoadScene("");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            GetHP();
            Destroy(collision.gameObject);
        }
    }
    public void GetHP()
    {
        _health -= _stoneDamege;
    }
}
