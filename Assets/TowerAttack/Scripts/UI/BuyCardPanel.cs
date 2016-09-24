using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyCardPanel : MonoBehaviour {
    public CardType cardType;
    Button buyButton;

    void Start () {
	    if(cardType != null)
        {
            this.transform.FindChild("CardImage").GetComponent<Image>().sprite = cardType.cardImage;
            this.transform.FindChild("CardName").GetComponent<Text>().text = cardType.cardName;
            this.transform.FindChild("CardCost").GetComponent<Text>().text = "$" + cardType.cost;
            this.transform.FindChild("CardDescription").GetComponent<Text>().text = cardType.cardDescription;
        }

        buyButton = this.transform.FindChild("BuyButton").GetComponent<Button>();
        buyButton.onClick.AddListener(() => BuyCard());
    }

    void Update()
    {
        PlayerData player = PlayerData.main;
        if(player != null && cardType != null)
        {
            buyButton.interactable = player.money >= cardType.cost;
        } else
        {
            buyButton.interactable = false;
        }
    }

    public void BuyCard()
    {
        PlayerData player = PlayerData.main;
        if(player.money >= cardType.cost)
        {
            player.money -= cardType.cost;
            player.deck.Add(cardType);
            player.Save();
        }
    }
	
	
}
