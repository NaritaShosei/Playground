using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private void Start()
    {
        scoreText.text = ScoreCount.count.ToString();
    }

}
