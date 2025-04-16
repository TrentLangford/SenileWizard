using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    public int FrameBuffer = 30;
    int counter;
    void Update()
    {
        counter++;
        if (Input.anyKeyDown && counter > FrameBuffer) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
