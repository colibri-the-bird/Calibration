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
    private void OnCollisionEnter(Collision collision)
    {
        if ((Break)&&(collision.collider.tag == "Player"))
        {
            Destroy(gameObject);
        }
    }
}
