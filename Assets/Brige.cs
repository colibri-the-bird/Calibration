using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Brige : MonoBehaviour
{
    public GameObject[] gameObjects;
    void Start()
    {
        
        foreach (GameObject obj in gameObjects)
        {
            int ind = UnityEngine.Random.Range(0, 2);
            obj.transform.GetChild(ind).GetComponent<BrigePart>().Break = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
