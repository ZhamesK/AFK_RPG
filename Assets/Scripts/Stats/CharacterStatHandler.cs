using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStat baseStat;

    public PlayerStat CurrentStat { get; private set; } = new();

    public List<PlayerStat> statModifiers = new List<PlayerStat>();

    private readonly int MinAttack = 10;
    private readonly int MinDefense = 5;

    private readonly float MinSpeed = 0.8f;

    private readonly int MinMaxHealth = 5;

    public void Awake()
    {
        if (baseStat.itemSO != null)
        {
            baseStat.itemSO = Instantiate(baseStat.itemSO);
            CurrentStat.itemSO = Instantiate(baseStat.itemSO);
        }

        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        ApplyStatModifiers(baseStat);

        foreach (var modifier in statModifiers.OrderBy(o => o.statsChangeType))
        {
            ApplyStatModifiers(modifier);
        }
    }

    private void ApplyStatModifiers(PlayerStat modifier)
    {
        Func<float, float, float> operation = modifier.statsChangeType switch
        {
            StatsChangeType.Add => (current, change) => current + change,
            StatsChangeType.Multiple => (current, change) => current * change,

            _ => (current, change) => change,
        };

        UpdateBasicStats(operation, modifier);
        UpdateAttackStats(operation, modifier);
    }

    private void UpdateBasicStats(Func<float, float, float> operation, PlayerStat modifier)
    {
        CurrentStat.maxHealth = Mathf.Max((int)operation(CurrentStat.maxHealth, modifier.maxHealth), MinMaxHealth);
        CurrentStat.speed = Mathf.Max(operation(CurrentStat.speed, modifier.speed), MinSpeed);
    }

    private void UpdateAttackStats(Func<float, float, float> operation, PlayerStat modifier)
    {
        if (CurrentStat.itemSO == null || modifier.itemSO == null) return;

        var currentAttack = CurrentStat.itemSO;
        var newAttack = modifier.itemSO;

        currentAttack.attack = Mathf.Max((int)operation(currentAttack.attack, newAttack.attack), (int)MinAttack);
        currentAttack.defense = Mathf.Max((int)operation(currentAttack.defense, newAttack.defense), (int)MinDefense);
        currentAttack.speed = Mathf.Max(operation(currentAttack.speed, newAttack.speed), MinSpeed);
    }


    // 외부에서 스탯 변화 얻음
    public void AddStatModifier(PlayerStat statModifier)
    {
        statModifiers.Add(statModifier);
        UpdateCharacterStat();
    }

    // Stat 변화 해제
    public void RemoveStatModifier(PlayerStat statModifier)
    {
        statModifiers.Remove(statModifier);
        UpdateCharacterStat();
    }
}
