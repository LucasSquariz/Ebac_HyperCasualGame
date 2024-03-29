using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    [SerializeField, BoxGroup("References")] public Collider coinCollider;

    [SerializeField, BoxGroup("Coin Collectable config")] public bool collect = false;
    [SerializeField, BoxGroup("Coin Collectable config")] public float lerp = 5f;
    [SerializeField, BoxGroup("Coin Collectable config")] public float minDistance = 1.2f;

    private void Start()
    {
        CoinsAnimationManager.Instance.RegisterCoin(this);    
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        coinCollider.enabled = false;
        collect = true;        
    }

    protected override void Collect()
    {
        OnCollect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideItems();
                Destroy(gameObject);
            }
        }
    }
}
