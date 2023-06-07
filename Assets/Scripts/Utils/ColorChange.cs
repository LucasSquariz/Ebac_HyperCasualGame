using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    [SerializeField, BoxGroup("References")] public MeshRenderer meshRenderer;

    [SerializeField, BoxGroup("Color config")] public float colorChangeDuration = .2f;
    [SerializeField, BoxGroup("Color config")] public Color startColor = Color.white;

    [ShowNonSerializedField] private Color _originalColor;
    private void OnValidate()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _originalColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_originalColor, colorChangeDuration).SetDelay(.5f);
    }    
}
