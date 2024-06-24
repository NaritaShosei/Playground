using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisObject : MonoBehaviour
{
    [SerializeField] float _invokeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _invokeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
