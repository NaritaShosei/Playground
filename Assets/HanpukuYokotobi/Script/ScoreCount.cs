using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public float _plyerMoveRange;
    Transform Transform;
    public static int count = 0;
    public static bool _isCount = true;
    //bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        count = 0;
        //Transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Transform.transform.position.x == -_plyerMoveRange && check  )
        //{
        //    GetCount();
        //    check = false;
        //}
        //if (Transform.transform.position.x == _plyerMoveRange)
        //{
        //    check = true;
        //}
    }
    public void GetCount()
    {
            count += 50;

    }
    
}
