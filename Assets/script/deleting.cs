using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleting : MonoBehaviour
{
    void Start()
    {
        Destroy(GameObject.Find("bgm"));
    }
}
