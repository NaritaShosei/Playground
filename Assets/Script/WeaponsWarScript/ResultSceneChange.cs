using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneChange : MonoBehaviour
{
    [SerializeField] WeaponsPlayerMoveSword _weaponsPlayerMoveSword;
    [SerializeField] WeaponsPlayerMoveSpear _weaponsPlayerMoveSpear;
    SceneChangeManager _sceneChangeManager;
    // Start is called before the first frame update
    void Start()
    {
        _sceneChangeManager = GameObject.Find("SceneChange").GetComponent<SceneChangeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_weaponsPlayerMoveSword.IsSwordAlive && !_weaponsPlayerMoveSpear.IsSpearAlive)
        {
            _sceneChangeManager.Result();
        }
    }
}
