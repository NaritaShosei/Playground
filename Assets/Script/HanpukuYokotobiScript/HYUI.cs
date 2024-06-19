using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HYUI : MonoBehaviour
{
    public GameObject _count_object = null; // Textオブジェクト
    public GameObject _player = null;
    Text Count_text;
    void Start()
    {
        Count_text = _count_object.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Count_text.text = ScoreCount.score.ToString();
    }
}
