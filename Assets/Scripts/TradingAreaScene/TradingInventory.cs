using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// At scene start, randomly determine one tradeable good that the player doesn't have but needs.
/// Ensure that one of the TRADERS has it & wants a randmoly generated good that the player has.
/// 
/// </summary>
public class TradingInventory : MonoBehaviour
{
    public enum TradeableGoods
    {
        Wood,
        Metals,
        Food,
        MedicinalSupplies,
        ToolsAndWeapons,
        Booze,
    }

    public List<GameObject> GameObjectLocations;
    public TradeableGoods missingGood;
    public List<TradeableGoods> ownedGoods;

    int goodsDesired = 3;

    private void OnValidate()
    {
        if (GameObjectLocations.Capacity != Enum.GetNames(typeof(TradeableGoods)).Length)
        {
            GameObjectLocations.Capacity = Enum.GetNames(typeof(TradeableGoods)).Length;
        }
    }



    void Awake()
    {
        missingGood = randomGood();

        for (int i = 0; i < goodsDesired; i++)
        {
            ownedGoods.Add(randomGood());
            if (ownedGoods[i] == missingGood)
            {
                ownedGoods.Remove(ownedGoods[i]);
                i--;
            }
        }

    }

    TradeableGoods randomGood() 
    {
        return (TradeableGoods)(Random.Range(0, Enum.GetNames(typeof(TradeableGoods)).Length));
    }
}
