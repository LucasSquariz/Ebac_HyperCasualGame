using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpriteAstronaultController : MonoBehaviour
{
    public UnityEvent<Collision> onCollisionEnter;
    public UnityEvent<Collider> onTriggerEnter;

    private void OnCollisionEnter(Collision collision)
    {
        onCollisionEnter?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }
}
