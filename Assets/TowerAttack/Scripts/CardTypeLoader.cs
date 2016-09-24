using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// O CardTypeLoader, quando adicionado a uma cena,
/// carrega todos os CardTypes do projeto. Ele é usado para
/// encontrar um CardType a partir de seu CardId
/// </summary>
public class CardTypeLoader : MonoBehaviour {
    public static CardTypeLoader instance;

    public Dictionary<string, CardType> cardTypeCatalog;

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this.gameObject);
        }

        CardType[] existingCardTypes = Resources.LoadAll < CardType > ("CardTypes");
        cardTypeCatalog = new Dictionary<string, CardType>();
        foreach (CardType c in existingCardTypes)
        {
            if(cardTypeCatalog.ContainsKey(c.cardId))
            {
                Debug.LogError("CardId duplicado: " + c.cardId);
            }
            cardTypeCatalog.Add(c.cardId, c);   
        }
	}
	
    public CardType FindCardById(string cardId)
    {
        return cardTypeCatalog[cardId];
    }
}
