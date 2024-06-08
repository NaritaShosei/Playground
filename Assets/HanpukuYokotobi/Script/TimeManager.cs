using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float _time = 0f;
    Text _timeText;
    // Start is called before the first frame update
    void Start()
    {
        _timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        if (_time == 0f)
        {

        }
        _timeText.text = _time.ToString("F1");
    }
}
