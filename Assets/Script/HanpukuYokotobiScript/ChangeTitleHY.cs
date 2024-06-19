using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeTitleHY : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Play();
            Invoke("Load", 0.5f);

        }
    }
    public void Load()
    {

        SceneManager.LoadScene("TitleHY");
    }
}
