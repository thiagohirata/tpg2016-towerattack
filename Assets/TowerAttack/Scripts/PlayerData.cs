using UnityEngine;
using UnityEngine.SceneManagement;
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
        SaveData sd = new SaveData();
        sd.money = this.money;
        sd.deck = new String[this.deck.Count];
        for(int i = 0; i < this.deck.Count; i++)
        {
            sd.deck[i] = this.deck[i].cardId;
        }


        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(this.SaveDataFilePath, FileMode.OpenOrCreate);
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

    public void ResetSave()
    {
        File.Delete(this.SaveDataFilePath);
        DestroyObject(PlayerData.main.gameObject);
        SceneManager.LoadScene("Shop");

    }

    public void Load()
    {
        if(CardTypeLoader.instance == null)
        {
            //não vou conseguir carregar as cartas
            throw new Exception("Não é possível carregar as cartas sem um CardTypeLoader");
        }

        if(File.Exists(this.SaveDataFilePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = File.Open(this.SaveDataFilePath, FileMode.Open);
            SaveData sd = (SaveData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            if(sd.deck != null)
            {
                this.deck = new List<CardType>();
                foreach(String cardId in sd.deck) {
                    this.deck.Add(CardTypeLoader.instance.FindCardById(cardId));
                }
            }
            this.money = sd.money;
        }
    }

    [Serializable]
    public class SaveData
    {
        public int money;
        public string[] deck;
    }
}

