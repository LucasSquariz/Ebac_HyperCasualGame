using DG.Tweening;
using Ebac.Core.Singleton;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    [SerializeField, BoxGroup("References")] public List<ItemCollectableCoin> itens;

    [SerializeField, BoxGroup("Animation config")] public float scaleDuration = .2f;
    [SerializeField, BoxGroup("Animation config")] public float scaleTimeBetweenPieces = .1f;
    [SerializeField, BoxGroup("Animation config")] public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollectableCoin>();
    }   

    public void RegisterCoin(ItemCollectableCoin coin)
    {
        if(!itens.Contains(coin))
        {
            itens.Add(coin);
            coin.transform.localScale = Vector3.zero;
        }
        
    }

    public void StartAnimations()
    {
        StartCoroutine(ScaleCoinsByTime());
    }

    IEnumerator ScaleCoinsByTime()
    {
        foreach (var coin in itens)
        {
            coin.transform.localScale = Vector3.zero;
        }
        SortCoins();
        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void SortCoins()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
