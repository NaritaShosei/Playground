using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerator : MonoBehaviour
{
    [Header("�v���C���[")]
    [SerializeField] GameObject _playerSword;
    [SerializeField] GameObject _playerSpear;
    CinemachineVirtualCamera _cinemachine;
    EnemyGenerator _enemyGenerator;
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
        _enemyGenerator = GameObject.Find("Main Camera").GetComponent<EnemyGenerator>();
        if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.sword)
        {
            WeaponsPlayerMoveSpear.IsSpearAlive = false;
            Destroy(_playerSpear);
            _cinemachine.Follow = _playerSword.transform;
            _enemyGenerator._playerTransform = _playerSword.transform;
        }
        if (PlayerGenerator.playerAlive == PlayerGenerator.PlayerAlive.spear)
        {
            WeaponsPlayerMoveSword.IsSwordAlive = false;
            Destroy(_playerSword);
            _cinemachine.Follow = _playerSpear.transform;
            _enemyGenerator._playerTransform = _playerSpear.transform;
        }
    }
}
