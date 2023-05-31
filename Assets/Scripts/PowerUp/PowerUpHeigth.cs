using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeigth : PowerUpBase
{
    [SerializeField, BoxGroup("Height config")] public float increasedHeight = 2f;
    [SerializeField, BoxGroup("Height config")] public float animationDuration = .2f;
    [SerializeField, BoxGroup("Height config")] public DG.Tweening.Ease easeAnimation = DG.Tweening.Ease.OutBack;
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetTextPowerUp("Voando");
        PlayerController.Instance.ChangeHeight(increasedHeight, powerUpDuration, animationDuration, easeAnimation);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetTextPowerUp("");        
    }
}
