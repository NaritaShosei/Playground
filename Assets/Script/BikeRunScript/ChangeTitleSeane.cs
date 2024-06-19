using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTitleSeane : MonoBehaviour
{
    int countMaou = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            countMaou++;
            if (countMaou == 1)
            {
                GetComponent<AudioSource>().Play();
                Invoke("Title", 1f);
            }

        }
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
        HealthSystem._health = 2;
    }
}
