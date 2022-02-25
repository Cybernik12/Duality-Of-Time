using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    private int gems;

    private float wait = 0.5f;
    private float timer;

    private void Awake()
    {
        timer = wait;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            FindObjectOfType<AudioManager>().Play("Pickup");
            Destroy(collision.gameObject);
            gems += 1;
            Debug.Log("Gem!!");
        }

        if (collision.gameObject.tag == "Death")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("You Died!!");
        }

        if (collision.gameObject.tag == "Win")
        {
            if (gems >= 1)
            {
                SceneManager.LoadScene("LevelSelect");
            }
            Debug.Log("You Win!!");
        }
    }
}
