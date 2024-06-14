using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] public float _plyerMoveRange;
    Transform Transform;
    public static int score = 0;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GetCount()
    {
            score += 50;

    }
    
}
