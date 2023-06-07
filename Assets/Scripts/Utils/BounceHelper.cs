using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceHelper : MonoBehaviour
{
    [SerializeField, BoxGroup("Animation config")] public float scaleDuration = .2f;    
    [SerializeField, BoxGroup("Animation config")] public Ease ease = Ease.OutBack;
   
    public void Bounce(float scaleBounce)
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }
}
