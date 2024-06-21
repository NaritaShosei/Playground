using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [SerializeField] GameObject _playerSword;
    [SerializeField] GameObject _playerSpear;
    CinemachineVirtualCamera _cinemachine;
    public static PlayerAlive playerAlive;
    public enum PlayerAlive
    {
        sword,
        spear
    }
    // Start is called before the first frame update
    void Start()
    {
        WeaponsPlayerMoveSpear.IsSpearAlive = true;
        WeaponsPlayerMoveSword.IsSwordAlive = true;
        _cinemachine = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.sword)
        {
            WeaponsPlayerMoveSpear.IsSpearAlive = false;
            Destroy(_playerSpear);
            _cinemachine.Follow = _playerSword.transform;
        }
        if (PlayerGenerator.playerAlive == PlayerAlive.spear)
        {
            WeaponsPlayerMoveSword.IsSwordAlive = false;
            Destroy(_playerSword);
            _cinemachine.Follow = _playerSpear.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
