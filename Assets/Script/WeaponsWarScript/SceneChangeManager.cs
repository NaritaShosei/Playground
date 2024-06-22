using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    AudioSource _selectAudio;
    public int _pushCount;
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
            Invoke(nameof(GetTitle), 1f);
        }
        _pushCount = 1;
    }
    public void InGame()
    {
        if (_pushCount == 0)
        {
            _selectAudio.Play();
            Invoke(nameof(GetInGame), 1f);
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
}
