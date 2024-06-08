using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] public float _time = 0f;
    Text _timeText;
    public bool IsInGame = true;

    // Start is called before the first frame update
    void Start()
    {
        _timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = _time.ToString("F1");
        if (_time <= 0f)
        {
            _timeText.text = ("STOP");
            IsInGame = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Invoke("GetScene", 1f);
            }
        }
    }
    public void GetScene()
    {
        SceneManager.LoadScene("Result");
    }
}
