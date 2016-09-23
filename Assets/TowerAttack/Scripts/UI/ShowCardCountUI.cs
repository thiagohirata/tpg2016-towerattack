using UnityEngine;
using System.Collections;

public class ShowCardCountUI : MonoBehaviour {

	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = PlayerData.main.deck.Count.ToString();

    }
}
