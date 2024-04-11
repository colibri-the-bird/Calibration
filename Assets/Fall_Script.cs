using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Script : MonoBehaviour
{
    public bool fall;
    private float stay;
    public GameObject PlayerCon;
    public Transform FloorLevel;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = PlayerCon.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        stay = transform.position.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall&&(transform.position.y <= stay))
        {
            rb.isKinematic = false;
        }
    }
}
