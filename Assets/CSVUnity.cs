using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVUnity : MonoBehaviour
{
    public TextAsset textAssetData;
    // Start is called before the first frame update
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
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 4 - 1;
        myPlayerList.player = new Player[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            myPlayerList.player[i] = new Player();
            myPlayerList.player[i].name = data[4 * (i + 1)];
            myPlayerList.player[i].mmr = int.Parse(data[4 * (i + 1) + 1]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
