using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive_Ghost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Fall_Script>() != null)
        {
            if ((other.gameObject.GetComponent<Fall_Script>().GhostForm == true)&& 
                (other.gameObject.GetComponent<Fall_Script>().HP > 0 ))
            {
                other.gameObject.GetComponent<Fall_Script>().GhostForm = false;
                other.gameObject.GetComponent<Fall_Script>().HP--;
            }
        }
    }
}
