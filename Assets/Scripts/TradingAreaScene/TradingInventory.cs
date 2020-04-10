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
/// 

public enum TradeableGoods
{
    Wood,
    Metals,
    Food,
    MedicinalSupplies,
    ToolsAndWeapons,
    Booze,
}


public class TradingInventory : BaseEvent
{
    [Header("Core bits")]
    public NavMeshAgent agent;
    public GameObject player;
    [Tooltip("This should be the centreEye GO")]
    public GameObject headCenter;
    public Stage2 secondStage;

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
    bool hasRequiredGood = false;


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
        TradeableGoods tradersOwnedGood = other.gameObject.GetComponent<TradingResource>().ownedGood;
        TradeableGoods tradersDesiredGood = other.gameObject.GetComponent<TradingResource>().desiredGood;

        if (ownedGoods.Contains(tradersDesiredGood))
        {
            StartCoroutine(executeTrade(tradersOwnedGood, tradersDesiredGood, ownedGoods));
        }

        print("Am looking at " + lookingAtObject);
    }

    private void OnTriggerExit(Collider other)
    {
        lookingAtObject = null;
        //stop any trading sounds, if playing
    }

    IEnumerator executeTrade(TradeableGoods traderOwnedGood, TradeableGoods traderDesiredGood, List<TradeableGoods> playersGoods) 
    {
        //Start playing some babling/trading noises?
        yield return new WaitForSeconds(5f);
        //Stop them playing
        if (playersGoods.Contains(traderDesiredGood))
        {
            playersGoods.Remove(traderDesiredGood);
            playersGoods.Add(traderOwnedGood);
        }
        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (ownedGoods.Contains(missingGood))
        {
            hasRequiredGood = true;
        }

        if (hasRequiredGood)
        {
            secondStage.enabled = true;
        }
    }
}
