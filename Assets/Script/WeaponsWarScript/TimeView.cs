using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeView : MonoBehaviour
{
    [SerializeField] Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text.text = WeaponsWarTimeManager._timer.ToString("F2") + " �b�Ԃ����̂т��I�I";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
