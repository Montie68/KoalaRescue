using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DBRObjects;

public class ClearCoins : Editor
{
    [MenuItem("Tools/Drop Bear Run/Clear Coins", false, 21)]
    private static void ClearCoinCount()
    {
        InGameCurrency.SaveCurrency(0);
    }
    [MenuItem("Tools/Drop Bear Run/Add 10 Coins", false, 21)]
    private static void AddCoinCount()
    {
        InGameCurrency.SaveCurrency(10 + InGameCurrency.LoadCurrency());
    }

}
