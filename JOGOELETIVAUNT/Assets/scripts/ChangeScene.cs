using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public static bool pm2 = true;


    private void Awake()
    {
    }
    public void ChangeS()
    {
        SceneManager.LoadScene(SceneName);
        
    }

    public void multichosse()
    {
        pm2 = false;

    }

    public void Sair()
    {
        Application.Quit();
    }
}
