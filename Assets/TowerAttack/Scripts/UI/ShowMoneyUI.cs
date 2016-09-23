using UnityEngine;
using System.Collections;

public class ShowMoneyUI : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = PlayerData.main.money.ToString();
	}
}
