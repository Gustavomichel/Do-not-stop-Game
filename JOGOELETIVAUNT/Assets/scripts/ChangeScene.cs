using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public bool p2 = true;

    public void ChangeS()
    {
        SceneManager.LoadScene(SceneName);
        
    }

    public void multichosse()
    {
        p2 = false;
    }

    public void Sair()
    {
        Application.Quit();
    }
}
