using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Items/Euqipment", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("Equipment Info")]
    public int price;
    public int attack;
    public int defense;
    public float speed;
}
