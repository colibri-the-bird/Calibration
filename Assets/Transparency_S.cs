using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency_S : MonoBehaviour
{
    // Start is called before the first frame update
    public float trans;
    Material mat;
    public Transform player;
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Color oldColor = mat.color;
        trans = 1 - Vector3.Distance(transform.position,player.position)/4;
        if (trans > 1 ) trans = 1;
        if (trans < 0 ) trans = 0;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, trans);
        mat.SetColor("_Color", newColor);
    }
}
