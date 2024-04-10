using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static UnityEditor.SceneView;

public class SaveLoadManager : MonoBehaviour
{
    string filePath;
    public GameObject obj;
    public GameObject load_obj;
    public List<float[]> listD = new List<float[]>();

    // Start is called before the first frame update
    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.scene";
    }

    public void SaveScene()
    {
        listD = obj.GetComponent<SetObstacles>().detailsData;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        save.SaveData(listD);
        bf.Serialize(fs, save);
        fs.Close();
    }

    public void LoadScene()
    {
        if (!File.Exists(filePath))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();
        load_obj.GetComponent<Load>().det = save.Details;
        load_obj.GetComponent<Load>().e = true;

    }
}

[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct Vec3
    {
        public float x, y, z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct DetailSaveData
    {
        public Vec3 Position, Scale;

        public DetailSaveData(Vec3 pos, Vec3 sca)
        {
            Position = pos;
            Scale = sca;
        }
    }

    public List<DetailSaveData> Details =
        new List<DetailSaveData>();

    public void SaveData(List<float[]> data)
    {
        foreach (float[] dataItem in data)
        {
            Vec3 pos = new Vec3(dataItem[0], dataItem[1], dataItem[2]);
            Vec3 sca = new Vec3(dataItem[3], dataItem[4], dataItem[5]);

            Details.Add(new DetailSaveData(pos, sca));
        }
    }
}
