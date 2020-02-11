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
        Grain,
        MedicinalSupplies,
        ToolsAndWeapons,
    }

    public TradeableGoods missingGood;
    public List<TradeableGoods> ownedGoods;

    int goodsDesired = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        for (int i = 0; i < goodsDesired; i++)
        {
            int randomSelection = Random.Range(0, 5);
            
        }
    }

    TradeableGoods randomGood() 
    {
        return (TradeableGoods)(Random.Range(0, Enum.GetNames(typeof(TradeableGoods)).Length));
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
