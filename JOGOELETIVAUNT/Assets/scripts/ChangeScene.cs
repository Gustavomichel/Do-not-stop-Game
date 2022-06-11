using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;

    public void ChangeS()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
