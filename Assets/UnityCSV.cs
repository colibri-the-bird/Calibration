using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class UnityCSV : MonoBehaviour
{
    string filename = "";

    [System.Serializable]

    public class Player
    {
        public string name;
        public int mmr;
    }
    [System.Serializable]

    public class PlayerList
    {
        public Player[] player;
    }
    public PlayerList myPlayerList = new PlayerList();
    void Start()
    {
        filename = Application.dataPath + "/reating";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            WriteCSV();
    }
    public void WriteCSV()
    {
        if(myPlayerList.player.Length > 0)
        {
            TextWriter tw =  new StreamWriter(filename, false);
            tw.WriteLine("Name, MMR");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < myPlayerList.player.Length; i++)
            {
                tw.WriteLine(myPlayerList.player[i].name + "," + myPlayerList.player[i].mmr);
            }
            tw.Close();
        }
    }
}
