using UnityEngine;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class PlayerData : MonoBehaviour {
    public List<CardType> deck;
    public int money;
    public static PlayerData main;

	void Start () {
        //Implementação meio tosca de singleton
        if(PlayerData.main != null)
        {
            Destroy(this.gameObject);
        }
        PlayerData.main = this;

        //carregar dados do Save Game
        Load();

        //mantem o objeto válido, mesmo se trocar de cena
        DontDestroyOnLoad(this.gameObject);
    }
    

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(this.SaveDataFilePath, FileMode.OpenOrCreate);

        SaveData sd = new SaveData();
        sd.money = this.money;


        binaryFormatter.Serialize(fileStream, sd);
        fileStream.Close();
    }

    public String SaveDataFilePath
    {
        get
        {
            return Application.persistentDataPath + "/save01.dat";
        }
    }

    public void Load()
    {
        if(File.Exists(this.SaveDataFilePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(this.SaveDataFilePath, FileMode.Open);
            
            SaveData sd = (SaveData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            this.money = sd.money;
        }
    }

    [Serializable]
    public class SaveData
    {
        public int money;
    }
}

