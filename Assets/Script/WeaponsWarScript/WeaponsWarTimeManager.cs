using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsWarTimeManager : MonoBehaviour
{
    public float _timer = 0;
    [SerializeField] Text _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        _text.text ="êßå¿éûä‘ : " + _timer.ToString("F2");
    }
}
