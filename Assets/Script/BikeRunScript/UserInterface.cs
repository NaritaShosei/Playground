using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class
UserInterface : MonoBehaviour
{
    
    public GameObject HP_object = null; // Textオブジェクト
    public GameObject player = null;

    Text HP_text;
    // 初期化
    void Start()
    {
        HP_text =  HP_object.GetComponent<Text>();
    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        // テキストの表示を入れ替える
        HP_text.text = "HP: " + HealthSystem._health.ToString();
    }
}
