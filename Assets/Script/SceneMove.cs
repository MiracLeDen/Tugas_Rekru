using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMove : MonoBehaviour
{
    public void ToScene2()
    {
     SceneManager.LoadScene("Scene2");   
    }
    public void ToScene3()
    {
     SceneManager.LoadScene("Scene3");   
    }
}
