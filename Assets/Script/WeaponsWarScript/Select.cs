using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static int _selectedWeapon = 0;
    AudioSource _selectAudio;
    SceneChangeManager _sceneChangeManager;
    // Start is called before the first frame update
    void Start()
    {
        _selectAudio = GetComponent<AudioSource>();
        _sceneChangeManager = GameObject.Find("SceneChange").GetComponent<SceneChangeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectedSword()
    {
        if (_sceneChangeManager._pushCount == 0)
        {
            PlayerGenerator.playerAlive = PlayerGenerator.PlayerAlive.sword;
            _selectAudio.Play();
        }
    }
    public void SelectedSpear()
    {
        if (_sceneChangeManager._pushCount == 0)
        {
            PlayerGenerator.playerAlive = PlayerGenerator.PlayerAlive.spear;
            _selectAudio.Play();
        }
    }
}
