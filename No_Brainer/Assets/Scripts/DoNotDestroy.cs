using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("gameMusic");

        for (int i = musicObj.Length - 1; i >= 1; i--)
        {
            Destroy(musicObj[i]);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}