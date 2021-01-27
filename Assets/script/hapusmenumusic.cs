using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hapusmenumusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("music"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
