using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlgo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "lvlchange1")
        {
            SceneManager.LoadScene("lvl2");

        }
    }
}
