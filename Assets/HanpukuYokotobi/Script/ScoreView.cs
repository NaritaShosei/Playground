using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text scoreText;
    ScoreCount _scoreCount2;
    private void Start()
    {
        _scoreCount2 = FindAnyObjectByType<ScoreCount>();
        scoreText.text = _scoreCount2.count.ToString();
    }

}
