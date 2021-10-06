using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void RePlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
