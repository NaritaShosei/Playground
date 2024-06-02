using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    //public AudioClip AudioClip;
    //private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        //AudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //AudioSource.clip = AudioClip;
            //AudioSource.Play();
            GetComponent<AudioSource>().Play();
            Invoke("Call",1f);
        }
    }
     void Call()
    {
        SceneManager.LoadScene("BikeRun");
    }
    //public void change_button()
    //{
    //    SceneManager.LoadScene("BikeRun");
    //    Debug.Log("jhjhjh");
    //}
}
