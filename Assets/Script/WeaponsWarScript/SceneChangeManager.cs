using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public  void Title()
    {
        SceneManager.LoadScene("WeaponsWarTitle");
    }
    public  void InGame()
    {
        SceneManager.LoadScene("WeaponsWar");
    }
    public  void Result()
    {
        SceneManager.LoadScene("WeaponsWarResult");
    }
}
