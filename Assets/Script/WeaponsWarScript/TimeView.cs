using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField] Text _timeText;
    [SerializeField] Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _timeText.text = WeaponsWarTimeManager._timer.ToString("F2") + " 秒間いきのびた！！";
        _scoreText.text = "SCORE : " + ScoreManager._score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
