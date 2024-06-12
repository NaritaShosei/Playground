using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HYUI : MonoBehaviour
{
    public GameObject _count_object = null; // Textオブジェクト
    public GameObject _player = null;
    Text Count_text;
    //ScoreCount _count;
    // Start is called before the first frame update
    void Start()
    {
        Count_text = _count_object.GetComponent<Text>();
        //_count = _player.GetComponent<ScoreCount>();
    }

    // Update is called once per frame
    void Update()
    {
        Count_text.text = ScoreCount.count.ToString();
    }
}
