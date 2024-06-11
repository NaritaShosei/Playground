using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevel : MonoBehaviour
{
    HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem =  GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            healthSystem._health = 1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            healthSystem._health = 2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            healthSystem._health = 3;
        }
    }
}
