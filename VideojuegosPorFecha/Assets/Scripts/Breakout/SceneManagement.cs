using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("BreakoutScene1");
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
