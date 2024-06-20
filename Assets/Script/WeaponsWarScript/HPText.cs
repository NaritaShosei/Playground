using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] GameObject WeaponsHP;
    [SerializeField] Text _textHp;
    WeaponsHP _platerHP;
    // Start is called before the first frame update
    void Start()
    {
        _platerHP = WeaponsHP.GetComponent<WeaponsHP>();
    }

    // Update is called once per frame
    void Update()
    {
        _textHp.text = "HP:"+ _platerHP._hp.ToString();
    }
}
