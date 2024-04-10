using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    private GameObject[] gameObjects;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjects.Length > 0)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObjects = gameObjects.Append(other.gameObject).ToArray();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObjects = gameObjects.Where(val => val != other.gameObject).ToArray();
        }
    }
}
