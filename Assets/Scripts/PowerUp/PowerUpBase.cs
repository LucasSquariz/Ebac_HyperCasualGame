using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [SerializeField, BoxGroup("PowerUpBase config")] public float powerUpDuration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
        PlayerController.Instance.Bounce(1.2f);
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), powerUpDuration);
    }

    protected virtual void EndPowerUp()
    {

    }
}
