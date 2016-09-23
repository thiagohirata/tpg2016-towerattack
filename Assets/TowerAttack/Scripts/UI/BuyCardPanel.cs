using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyCardPanel : MonoBehaviour {
    public CardType cardType;

    void Start () {
	    if(cardType != null)
        {
            this.transform.FindChild("CardImage").GetComponent<Image>().sprite = cardType.cardImage;
            this.transform.FindChild("CardName").GetComponent<Text>().text = cardType.cardName;
            this.transform.FindChild("CardCost").GetComponent<Text>().text = "$" + cardType.cost;
            this.transform.FindChild("CardDescription").GetComponent<Text>().text = cardType.cardDescription;
        }
    }
	
	
}
