using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigePart : MonoBehaviour
{
    public bool Break = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Fall_Script>() != null) 
        {
            if ((Break) && (other.tag == "MainCamera"))
            {
                StartCoroutine(Coroutine(other));
            }
            else { other.gameObject.GetComponent<Fall_Script>().fall = false; }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Fall_Script>() != null)
        {
            other.gameObject.GetComponent<Fall_Script>().fall = true;
        }
    }
    private IEnumerator Coroutine(Collider collider)
    {
        yield return new WaitForSeconds(0.1f);
        collider.gameObject.GetComponent<Fall_Script>().fall = true;
        Destroy(gameObject);
    }
}
