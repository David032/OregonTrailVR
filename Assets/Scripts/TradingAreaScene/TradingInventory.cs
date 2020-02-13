using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

/// <summary>
/// At scene start, randomly determine one tradeable good that the player doesn't have but needs.
/// Ensure that one of the TRADERS has it & wants a randmoly generated good that the player has.
/// 
/// </summary>
public class TradingInventory : MonoBehaviour
{
    [Header("Core bits")]
    public NavMeshAgent agent;
    public GameObject player;
    public enum TradeableGoods
    {
        Wood,
        Metals,
        Food,
        MedicinalSupplies,
        ToolsAndWeapons,
        Booze,
    }

    [Header("Goods")]
    public List<TradeableGoods> ownedGoods;
    public TradeableGoods missingGood;

    [Header("Traders")]
    public GameObject WoodTrader;
    public GameObject MetalTrader;
    public GameObject FoodTrader;
    public GameObject MedicalTrader;
    public GameObject ToolTrader;
    public GameObject BoozeTrader;

    int goodsDesired = 3;

    GameObject lookingAtObject;

    [Tooltip("This should be the centreEye GO")]
    public GameObject headCenter;

    private void OnValidate()
    {
        if (ownedGoods.Capacity != Enum.GetNames(typeof(TradeableGoods)).Length)
        {
            ownedGoods.Capacity = Enum.GetNames(typeof(TradeableGoods)).Length;
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

    private void OnTriggerEnter(Collider other)
    {
        lookingAtObject = other.gameObject;
        print("Am looking at " + lookingAtObject);
    }

    private void OnTriggerExit(Collider other)
    {
        print("Am not looking at " + lookingAtObject);
        lookingAtObject = null;
    }

}
