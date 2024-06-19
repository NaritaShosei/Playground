using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeHY : MonoBehaviour
{
    int countReturn = 0;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource Yoidon = GetComponent<AudioSource>();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            countReturn++;
            if (countReturn == 1)
            {
                Invoke("GetHYScene", 2.5f);
                Yoidon.Play();
                //SceneManager.LoadScene("HanpukuYokotobi");
            }
        }
    }
    public void GetHYScene()
    {
        SceneManager.LoadScene("HanpukuYokotobi");
    }
}
