using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] public float _time = 0f;
    [SerializeField] public float _pulusTime = 5f;
    Text _timeText;
    public bool IsInGame = true;
    AudioSource _audioSource;
    public int scoreLine = 500;
    public float mainasutime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _timeText = GetComponent<Text>();
        _audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = "Time : " +_time.ToString("F1");
        if (ScoreCount.score == scoreLine)
        {
            _time += _pulusTime;
            _pulusTime = _pulusTime - mainasutime;
            scoreLine += 500;
        }
        if (_time <= 0f)
        {
            _timeText.text = ("STOP");
            IsInGame = false;
            _audioSource.Stop();
            Invoke("GetScene", 1f);
        }
    }
    public void GetScene()
    {
        SceneManager.LoadScene("Result");
    }
}
