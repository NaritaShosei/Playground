using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static int _selectedWeapon = 0;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectedSword()
    {
        PlayerGenerator.playerAlive = PlayerGenerator.PlayerAlive.sword;
    }
    public void SelectedSpear()
    {
        PlayerGenerator.playerAlive = PlayerGenerator.PlayerAlive.spear;
    }
}
