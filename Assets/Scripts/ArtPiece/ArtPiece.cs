using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    [SerializeField, BoxGroup("References")] public GameObject currentArt;    
    public void ChangePiece(GameObject artPiece)
    {        
        if (currentArt != null) Destroy(currentArt);
        currentArt = Instantiate(artPiece, transform);       
    }
}
