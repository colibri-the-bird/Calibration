using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transparency_S : MonoBehaviour
{
    // Start is called before the first frame update
    public float[] trans;
    Material mat;
    public GameObject[] players;
    private int player_count;
    void Start()
    { 
        mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("OVRCamera");
        Color oldColor = mat.color;
        if (players.Length > player_count) 
        {
            trans = trans.Append(1).ToArray();
            player_count = players.Length;
        }
        for (int i = 0; i < trans.Length; i++)
        {
            trans[i] = 1 - Vector3.Distance(transform.position, players[i].transform.position)/4;
            if (trans[i] > 1)
            {
                trans[i] = 1;
            }
            if (trans[i] < 0)
            {
                trans[i] = 0;
            }
        }
        
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, trans.Max());
        mat.SetColor("_Color", newColor);
    }
}
