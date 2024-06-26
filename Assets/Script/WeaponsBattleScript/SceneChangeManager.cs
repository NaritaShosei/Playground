using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeManager : MonoBehaviour
{
    AudioSource _selectAudio;
    public int _pushCount;
    [SerializeField] GameObject _explanationText;
    [SerializeField] GameObject _textAndButton;
    [SerializeField] GameObject _button;
    [SerializeField] float _invokeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _selectAudio = GetComponent<AudioSource>();
        _pushCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Title()
    {
        if (_pushCount == 0)
        {
            _selectAudio.Play();
            Invoke(nameof(GetTitle), _invokeTime);
        }
        _pushCount = 1;
    }
    public void InGame()
    {
        if (_pushCount == 0)
        {
            _selectAudio.Play();
            Invoke(nameof(GetInGame), _invokeTime);
        }
        _pushCount = 1;
    }
    public void Result()
    {
        SceneManager.LoadScene("WeaponsWarResult");
    }
    //変数にシーンの名前を入れるとそのシーンに代わる
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void GetTitle()
    {
        SceneManager.LoadScene("WeaponsWarTitle");
    }
    public void GetInGame()
    {
        SceneManager.LoadScene("WeaponsWar");
    }
    public void GetText()
    {
        _explanationText.SetActive(true);
        _button.SetActive(true);
        _textAndButton.SetActive(false);
    }
    public void GetCanvas()
    {
        _explanationText.SetActive(false);
        _button.SetActive(false);
        _textAndButton.SetActive(true);
    }
}
