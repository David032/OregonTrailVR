using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingListController : MonoBehaviour
{
    public TextMeshProUGUI entry1;
    public TextMeshProUGUI entry2;
    public TextMeshProUGUI entry3;
    public TextMeshProUGUI needed;

    public TradingInventory inventory;

    // Update is called once per frame
    void Update()
    {
        entry1.text = inventory.ownedGoods[0].ToString();
        entry2.text = inventory.ownedGoods[1].ToString();
        entry3.text = inventory.ownedGoods[2].ToString();
        needed.text = inventory.missingGood.ToString();
    }
}
