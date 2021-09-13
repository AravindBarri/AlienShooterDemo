using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveMethods : MonoBehaviour
{
    public string GameName;
    public string PlayerName;
    public string Gender;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetData();
        GetData();
    }
    public void SetData()
    {
        string path = Application.persistentDataPath + "/Details.file";
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write("Game Name: " + GameName);
        print("\n");
        bw.Write("Player Name : " + PlayerName);
        bw.Write("Player Gender : " + Gender);

        bw.Close();
        fs.Close();
    }
    public void GetData()
    {
        string path = Application.persistentDataPath + "/Details.file";
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        br.ReadString();
        br.Close();
        fs.Close();
    }
}