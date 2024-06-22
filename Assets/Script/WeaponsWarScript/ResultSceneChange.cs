using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneChange : MonoBehaviour
{
    SceneChangeManager _sceneChangeManager;
    float _timer = 0;
    [SerializeField] float _changeTime;
    // Start is called before the first frame update
    void Start()
    {
        _sceneChangeManager = GameObject.Find("SceneChange").GetComponent<SceneChangeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WeaponsPlayerMoveSpear.IsSpearAlive);
        Debug.Log(WeaponsPlayerMoveSword.IsSwordAlive);
        if (WeaponsPlayerMoveSword.IsSwordAlive == false && WeaponsPlayerMoveSpear.IsSpearAlive == false)
        {
            _timer += Time.deltaTime;
            if (_timer >= _changeTime)
            {
                _sceneChangeManager.Result();
                Debug.Log("‘S–Å");
            }
        }
    }
}
