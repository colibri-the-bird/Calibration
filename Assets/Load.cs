using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Save;
using UnityEngine.SceneManagement;


public class Load : MonoBehaviour
{
    public List<DetailSaveData> det = new List<DetailSaveData>();
    public GameObject Wall;
    public GameObject Obstacle;
    public GameObject Player_Cam;
    public GameObject OVR_Cam;
    public GameObject Scene;
    public GameObject Parent;
    public GameObject Scene_Dir;
    float angle;
    public bool e;
    public bool s;
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
        if (OVRInput.GetUp(OVRInput.Button.Three))
        {
            s = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            SceneManager.LoadScene("Start");
        }
        if (s)
        {
            Debug.DrawLine(Scene.transform.position, Scene_Dir.transform.position);
            Debug.DrawLine(Scene.transform.position, new Vector3(det[0]._Direction.x, det[0]._Direction.y, det[0]._Direction.z));
        }
        
        if (e)
        {
            angle = Vector2.Angle(new Vector2(Scene_Dir.transform.position.x, Scene_Dir.transform.position.z), new Vector2(det[0]._Direction.x, det[0]._Direction.z));
            Scene.transform.eulerAngles = new Vector3(0, angle, 0);
            Scene.transform.position = new Vector3(Player_Cam.transform.position.x, 0, Player_Cam.transform.position.z);
            for (int i = 0; i < det.Count; i++)
            {
                if (i  == 0)
                {
                    var clone = Instantiate(Wall, new Vector3(det[0].Position.x, det[0].Position.y, det[0].Position.z) * OVR_Cam.transform.parent.localScale.y, Quaternion.identity, Parent.transform);
                    clone.transform.localScale = new Vector3(det[0].Scale.x, det[0].Scale.y, det[0].Scale.z) * OVR_Cam.transform.parent.localScale.y;
                }
                else
                {
                    var clone = Instantiate(Obstacle, new Vector3(det[i].Position.x, det[i].Position.y, det[i].Position.z) * OVR_Cam.transform.parent.localScale.y, Quaternion.identity, Parent.transform);
                    clone.transform.localScale = new Vector3(det[i].Scale.x, det[i].Scale.y, det[i].Scale.z) * OVR_Cam.transform.parent.localScale.y;
                }

            }

            e = false;
        }
        
        if (det.Count > 0)
        {
            var d = Vector3.Distance(Player_Cam.transform.position, new Vector3(det[0]._Direction.x, Player_Cam.transform.position.y, det[0]._Direction.z));
            print(d);
            if ((d <= 3)&&OVRInput.GetUp(OVRInput.Button.Four))
            {
                StartCoroutine(Coroutine());
            }
        }
        
    }
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(1);
        OVR_Cam.transform.eulerAngles += new Vector3(OVR_Cam.transform.eulerAngles.x,angle + 180, OVR_Cam.transform.eulerAngles.z);
        Parent.transform.eulerAngles += new Vector3(Parent.transform.eulerAngles.x, angle + 180, Parent.transform.eulerAngles.z);
    }
}
