using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changemode : MonoBehaviour
{
    private GameObject world2;
    public GameObject p2hearts;
    private void Awake()
    {
        world2 = GameObject.Find("World2");
        p2hearts = GameObject.Find("P2Hearts");

        if (ChangeScene.pm2 == false)
        {
            world2.SetActive(false);
            p2hearts.SetActive(false);
        }
    }
}
