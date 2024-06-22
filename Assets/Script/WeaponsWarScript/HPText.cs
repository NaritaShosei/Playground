using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [Header("テキスト")]
    [SerializeField] Text _textHp;
    [Header("表示する体力")]
    [SerializeField] WeaponsHP _playerSwordHP;
    [SerializeField] WeaponsHP _playerSpearHP;


    // Start is called before the first frame update
    void Start()
    {

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
