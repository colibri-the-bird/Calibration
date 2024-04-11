using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Fall_Script>() != null)
        {
            other.gameObject.GetComponent<Fall_Script>().rb.isKinematic = true;
            other.gameObject.GetComponent<Fall_Script>().GhostForm = true;
            other.gameObject.transform.parent.parent.parent.position = new Vector3 (other.transform.parent.parent.parent.position.x, other.gameObject.GetComponent<Fall_Script>().Y, other.transform.parent.parent.parent.position.z);
        }
    }
}
