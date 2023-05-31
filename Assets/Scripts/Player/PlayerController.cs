using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Ebac.Core.Singleton;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField, BoxGroup("References")] public GameObject endScreen;
    [SerializeField, BoxGroup("References")] public TextMeshPro uiTextPowerUp;

    [SerializeField, BoxGroup("Lerp setup")] public Transform target;
    [SerializeField, BoxGroup("Lerp setup")] public float lerpSpeed = 1f;

    [SerializeField, BoxGroup("Player setup")] public float speed = 1f;

    [ShowNonSerializedField] private string tagToCheckEnemy = "Enemy";
    [ShowNonSerializedField] private string tagToCheckEndLine = "EndLine";
    [ShowNonSerializedField] private Vector3 _pos;
    [ShowNonSerializedField] private bool _canRun;
    [ShowNonSerializedField] private float _currentSpeed;
    [ShowNonSerializedField] private bool _isInvencible;

    private void Start()
    {
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(tagToCheckEnemy))
        {
            if(!_isInvencible) EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagToCheckEndLine))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }

    #region POWERUPS
    public void SetTextPowerUp(string title)
    {
        uiTextPowerUp.text = title;
    }
    public void PowerUpSpeedUp(float speedUp)
    {
        _currentSpeed = speedUp;
    }

    public void PowerUpInvencible(bool invencibleStatus = true)
    {
        _isInvencible = invencibleStatus;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    #endregion
}
