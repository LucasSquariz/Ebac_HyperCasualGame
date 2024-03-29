using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [SerializeField, BoxGroup("SpeedUp config")] public float increasedSpeed;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetTextPowerUp("Gotta go FAST");
        PlayerController.Instance.PowerUpSpeedUp(increasedSpeed);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetTextPowerUp("");
        PlayerController.Instance.ResetSpeed();
    }
}
