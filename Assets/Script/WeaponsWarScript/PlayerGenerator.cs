using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] GameObject _playerSword;
    [SerializeField] GameObject _playerSpear;
    // Start is called before the first frame update
    void Start()
    {
        if (Select._selectedWeapon == 0)
        {
            Destroy(_playerSpear);
        }
        if (Select._selectedWeapon == 1)
        {
            Destroy(_playerSword);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
