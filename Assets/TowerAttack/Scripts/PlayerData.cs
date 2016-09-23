using UnityEngine;
using System.Collections.Generic;

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

        //TODO - carregar dados do Save Game

        //mantem o objeto válido, mesmo se trocar de cena
        DontDestroyOnLoad(this.gameObject);
    }

}
