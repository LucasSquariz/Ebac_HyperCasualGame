using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt artifacts;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextArtifacts;

    private void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.ToString());
        //UIInGameManager.UpdateTextArtifacts(artifacts.ToString());
        // uiTextCoins.text = coins.ToString();
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        artifacts.value = 0;
    }

    public void AddCoins(int amout = 1)
    {
        coins.value += amout;        
        UpdateUI();
    }

    public void AddArtifacts(int amout = 1)
    {
        artifacts.value += amout;
        UpdateUI();
    }
}
