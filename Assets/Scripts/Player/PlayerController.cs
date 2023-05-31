using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField, BoxGroup("References")] public GameObject endScreen;
    [SerializeField, BoxGroup("Lerp setup")] public Transform target;
    [SerializeField, BoxGroup("Lerp setup")] public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;

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
            EndGame();
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

    public void PowerUpSpeedUp(float speedUp)
    {
        _currentSpeed = speedUp;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    #endregion
}
