using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{    
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetTextPowerUp("Invencible");
        PlayerController.Instance.PowerUpInvencible(true);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetTextPowerUp("");
        PlayerController.Instance.PowerUpInvencible(false);
    }
}
