using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    [SerializeField, BoxGroup("Animation config")] public float scaleDuration = .2f;
    [SerializeField, BoxGroup("Animation config")] public float scaleBounce = 1.2f;
    [SerializeField, BoxGroup("Animation config")] public Ease ease = Ease.OutBack;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Bounce();
        }
    }
    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
