using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static int _selectedWeapon;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectedSword()
    {
        _selectedWeapon = 0;
    }
    void SelectedSpear()
    {
        _selectedWeapon = 1;
    }
}
