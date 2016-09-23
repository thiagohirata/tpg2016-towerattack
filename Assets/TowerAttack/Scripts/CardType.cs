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
    public int manaCost;
    /// <summary>
    /// Prefab gerado ao jogar a carta
    /// </summary>
    public GameObject playPrefab;
    /// <summary>
    /// Descrição da carta
    /// </summary>
    public string cardDescription;
}
