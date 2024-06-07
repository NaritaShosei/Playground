using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public float _plyerMoveRange;
    Transform Transform;
    public int count = -1;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Transform.transform.position.x == -_plyerMoveRange && check  )
        {
            GetCount();
            check = false;
        }
        if (Transform.transform.position.x == _plyerMoveRange)
        {
            check = true;
        }
    }
    public void GetCount()
    {
            count++;

    }
    
}
