using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changemode : MonoBehaviour
{
    private GameObject world2;
    private void Awake()
    {
        world2 = GameObject.Find("World2");

        if (ChangeScene.pm2 == false)
        {
            world2.SetActive(false);
        }
    }
}
