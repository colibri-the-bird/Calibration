using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

public class Load : MonoBehaviour
{
    public List<DetailSaveData> det = new List<DetailSaveData>();
    public bool e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (e)
        {
            print(det[0].Position.x);
        }
    }

}
