using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [SerializeField, BoxGroup("PowerUp Coin config")]public float sizeAmount = 11f;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetTextPowerUp("It's coin time");
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
        
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetTextPowerUp("");
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
}
