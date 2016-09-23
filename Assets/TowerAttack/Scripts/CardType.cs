using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Card", menuName = "TowerAttack/New Card")]
public class CardType : ScriptableObject {
    /// <summary>
    /// Nome da carta
    /// </summary>
    public string cardName;
    /// <summary>
    /// Custo da carta para comprar
    /// </summary>
    public int cost;
    /// <summary>
    /// Custo da carta para usar
    /// </summary>
    public int playCost;
    /// <summary>
    /// Descrição da carta
    /// </summary>
    public string cardDescription;
    /// <summary>
    /// Imagem da carta
    /// </summary>
    public Texture2D cardImage;
}
