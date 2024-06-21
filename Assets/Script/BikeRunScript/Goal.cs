using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D goalrb = GetComponent<Rigidbody2D>();
        goalrb.velocity = new Vector2(0,-30);
        if (Input.GetKey(KeyCode.Space))
        {
            goalrb.velocity = new Vector2(0, -30 * 2f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            goalrb.velocity = new Vector2(0, -30 );
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Clear");
        }
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(collision.gameObject);
            Debug.Log("Šâ‚ª”j‰ó‚³‚ê‚½");
        }
    }
}
