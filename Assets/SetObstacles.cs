using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using Oculus.Interaction;
using UnityEngine.SceneManagement;


public class SetObstacles : MonoBehaviour
{
    public float s_time;
    public GameObject Sphere;
    public GameObject Sphere2;
    public GameObject Cube;
    public GameObject Walls;
    public GameObject Camera_rig;
    public GameObject[] dots;
    [SerializeField] public List<float[]> detailsData = new List<float[]>(); 
    private Vector3 vector1;
    private Vector3 vector2;
    private int details_count;
    private bool two_dots;
    public bool CanSave;

    private float x;
    private float z;
    private float delta_x;
    private float delta_z;

    void Start()
    {
        
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            s_time += Time.deltaTime;
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            SceneManager.LoadScene("Main");
        }
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            if (s_time >= 1)
            {
                var clone = Instantiate(Sphere, this.transform.position, this.transform.rotation);
                dots = dots.Append(clone).ToArray();
                if (!two_dots)
                {
                    vector1 = clone.transform.position;
                    two_dots = true;
                }
                else
                {
                    vector2 = clone.transform.position;
                    details_count++;
                    two_dots = false;
                    if (details_count == 1) SetRoom();
                    if (details_count > 1) SpawnObstacle();
                    foreach (var dot in dots) 
                    {
                        Destroy(dot);
                        dots = dots.Where(val => val != dot).ToArray();
                    }
                }
            }
            s_time = 0;
        }
        if (OVRInput.GetUp(OVRInput.Button.Two) && CanSave)
        {
            SaveScenee();
            print("save");
            SceneManager.LoadScene("Start");
        }
        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Camera_rig.transform.eulerAngles = new Vector3 (Camera_rig.transform.eulerAngles.x,0, Camera_rig.transform.eulerAngles.z);
        }
    }
    void SpawnObstacle()
    {
        var position = vector1+(vector2 - vector1)/2f;
        var scale = new Vector3 (Mathf.Abs(vector2.x - vector1.x), Mathf.Abs(vector2.y - vector1.y), Mathf.Abs(vector2.z - vector1.z));
        var clone = Instantiate(Cube,position,Quaternion.identity);
        clone.transform.localScale = scale;
        detailsData.Add(new float[] { clone.transform.position.x, clone.transform.position.y, clone.transform.position.z, clone.transform.localScale.x, clone.transform.localScale.y, clone.transform.localScale.z,0,0,0});
    }
    void SetRoom()
    {
        var position = new Vector3(vector1.x + (vector2.x - vector1.x) / 2f, 0,vector1.z + (vector2.z - vector1.z) / 2f);
        var S = new Vector3(Mathf.Abs(vector2.x - vector1.x) , 25, Mathf.Abs(vector2.z - vector1.z));
        var clone = Instantiate(Walls, position, Quaternion.identity);
        clone.transform.localScale = S;
        
        if (clone.transform.localScale.x > clone.transform.localScale.z)
        { 
            z = clone.transform.position.z;
            x = clone.transform.position.x + clone.transform.localScale.x / 2f;
            delta_z = clone.transform.position.z;
            delta_x = clone.transform.position.x - clone.transform.localScale.x / 2f;
        }
        else
        {
            z = clone.transform.position.z + clone.transform.localScale.z / 2f;
            x = clone.transform.position.x;
            delta_z = clone.transform.position.z - clone.transform.localScale.z / 2f;
            delta_x = clone.transform.position.x;
        }
        detailsData.Add(new float[] { clone.transform.position.x, clone.transform.position.y, clone.transform.position.z, clone.transform.localScale.x, clone.transform.localScale.y, clone.transform.localScale.z, delta_x - x, 0, delta_z - z});
        Instantiate(Sphere2,new Vector3(x,0,z),Quaternion.identity);

    }
    void SaveScenee()
    {
        gameObject.GetComponent<SaveLoadManager>().SaveScene();
    }
}
