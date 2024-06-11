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
    ScoreCount _scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        _timeText = GetComponent<Text>();
        _audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        _scoreCount = GetComponent<ScoreCount>();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = _time.ToString("F1");
        //if (_scoreCount.count % 500 == 0)
        //{
        //    _time += _pulusTime;
        //}
        if (_time <= 0f)
        {
            _timeText.text = ("STOP");
            IsInGame = false;
            _audioSource.Stop();

            //if (Input.GetKeyDown(KeyCode.Return))
            //{
                Invoke("GetScene", 1f);
            //}
        }
    }
    public void GetScene()
    {
        SceneManager.LoadScene("Result");
    }
}
