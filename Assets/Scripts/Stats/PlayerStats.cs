using System;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}

[System.Serializable]
public class PlayerStat
{
    public StatsChangeType statsChangeType;
    [Range(0, 100)] public int maxHealth;
    [Range(0f, 20f)] public float speed;
    public ItemSO itemSO;
}
