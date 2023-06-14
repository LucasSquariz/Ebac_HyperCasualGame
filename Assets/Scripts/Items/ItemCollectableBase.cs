using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem itemParticleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;
    public AudioSource audioSource;
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void HideItems()
    {
        if (graphicItem != null) { graphicItem.SetActive(false); }
        Invoke("HideObject", timeToHide);
    }

    protected virtual void Collect() {
        HideItems();
        OnCollect();
    }    

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    {
        if (itemParticleSystem != null) {
            itemParticleSystem.transform.SetParent(null);
            itemParticleSystem.Play();
        }
        if (audioSource != null) audioSource.Play();
    }
}
