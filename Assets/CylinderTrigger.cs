using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SetObstacles>() != null)
        {
            other.GetComponent<SetObstacles>().CanSave = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent <SetObstacles>() != null)
        {
            other.GetComponent<SetObstacles>().CanSave = true;
        }
    }
}
