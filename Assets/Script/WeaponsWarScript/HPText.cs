using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] GameObject _swordHP;
    [SerializeField] GameObject _spearHP;
    [SerializeField] Text _textHp;
    WeaponsHP _playerSwordHP;
    WeaponsHP _playerSpearHP;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.sword)
        {
            _playerSwordHP = _swordHP.GetComponent<WeaponsHP>();
        }
        else if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.spear)
        {
            _playerSpearHP = _spearHP.GetComponent<WeaponsHP>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.sword)
        {
            _textHp.text = "HP:" + _playerSwordHP._hp.ToString();
        }
        else if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.spear)
        {
            _textHp.text = "HP:" + _playerSpearHP._hp.ToString();
        }
    }
}
