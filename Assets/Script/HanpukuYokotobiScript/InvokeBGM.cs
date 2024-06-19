using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeBGM : MonoBehaviour
{
    AudioSource _audioSource;
    // Start is called before the first frame update
   public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("GetBGM", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetBGM()
    {
        _audioSource.Play();
    }
}
