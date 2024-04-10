using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;

public class Load : MonoBehaviour
{
    public List<DetailSaveData> det = new List<DetailSaveData>();
    public GameObject Wall;
    public GameObject Obstacle;
    public GameObject Player_Cam;
    public GameObject Scene;
    public GameObject Scene_Dir;
    public bool e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            gameObject.GetComponent<SaveLoadManager>().LoadScene();
        }
        if (e)
        {
            float angle = Mathf.Atan2 (Scene_Dir.transform.position.x, Scene_Dir.transform.position.z) * Mathf.Rad2Deg - Mathf.Atan2(det[0]._Direction.x, det[0]._Direction.z)*Mathf.Rad2Deg ;
            Scene.transform.eulerAngles = new Vector3(0, angle,0);
            Scene.transform.position = new Vector3(Player_Cam.transform.position.x, 0, Player_Cam.transform.position.z);
            var clone = Instantiate(Wall, new Vector3(det[0].Position.x, det[0].Position.y, det[0].Position.z) * 3, Quaternion.identity);
            clone.transform.localScale = new Vector3(det[0].Scale.x, det[0].Scale.y, det[0].Scale.z)*3;
            e = false;
        }
    }

}
