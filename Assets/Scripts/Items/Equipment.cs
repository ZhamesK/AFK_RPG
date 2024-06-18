using System.Collections.Generic;
using UnityEngine;

public class Equipment : Items
{
    [SerializeField] private List<PlayerStat> statsModifier;
    protected override void OnPurchase(GameObject receiver)
    {
        CharacterStatHandler statHandler = receiver.GetComponent<CharacterStatHandler>();
        foreach (PlayerStat stat in statsModifier)
        {
            statHandler.AddStatModifier(stat);
        }
    }
}