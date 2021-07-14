using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(endLevel());
        }

    }


    IEnumerator endLevel()
    {
        // Move the first cube up or down.
        yield return new WaitForSeconds(0.1f);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene("Menu_Principal");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
