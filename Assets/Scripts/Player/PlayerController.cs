using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Ebac.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField, BoxGroup("References")] public GameObject endScreen;
    [SerializeField, BoxGroup("References")] public TextMeshPro uiTextPowerUp;
    [SerializeField, BoxGroup("References")] public GameObject coinCollector;
    [SerializeField, BoxGroup("References")] public AnimatorManager animatorManager;
    [SerializeField, BoxGroup("References")] public BounceHelper _bounceHelper;
    [SerializeField, BoxGroup("References")] public ParticleSystem vfxDeath;

    [SerializeField, BoxGroup("Lerp setup")] public Transform target;
    [SerializeField, BoxGroup("Lerp setup")] public float lerpSpeed = 1f;

    [SerializeField, BoxGroup("Player setup")] public float speed = 1f;
    [SerializeField, BoxGroup("Player setup")] public Vector2 limit = new Vector2(-4, 4);

    [ShowNonSerializedField] private string tagToCheckEnemy = "Enemy";
    [ShowNonSerializedField] private string tagToCheckEndLine = "EndLine";
    [ShowNonSerializedField] private Vector3 _pos;
    [ShowNonSerializedField] private Vector3 _startPosition;
    [ShowNonSerializedField] private Vector3 _inicialScale = Vector3.zero;
    [ShowNonSerializedField] private bool _canRun;
    [ShowNonSerializedField] private float _baseSpeedToAnimation = 7f;
    [ShowNonSerializedField] private float _currentSpeed;
    [ShowNonSerializedField] private bool _isInvencible;

    private void Start()
    {
        _startPosition = transform.position;
        transform.localScale = _inicialScale;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if( _pos.x < limit.x) _pos.x = limit.x;
        if (_pos.x > limit.y) _pos.x = limit.y;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    public void Bounce(float scaleBounce)
    {
        if(_bounceHelper != null) _bounceHelper.Bounce(scaleBounce);
    }

    public void OnEnemyCollisionEnter(Collision collision)
    {        
        if (collision.transform.CompareTag(tagToCheckEnemy))
        {
            if (!_isInvencible && _canRun) 
            {
                MoveBack(collision.transform);
                Bounce(0.5f);
                EndGame(AnimatorManager.AnimationType.DEAD); 
            }
        }
    }

    public void OnEndlineTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagToCheckEndLine))
        {
            EndGame();
        }
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    public void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.PlayAnimation(animationType);
        if(vfxDeath != null) vfxDeath.Play();
    }

    public void StartToRun()
    {
        _canRun = true;
        animatorManager.PlayAnimation(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
        Bounce(1.2f);
        transform.localScale = Vector3.one;
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

    public void ChangeHeight(float height, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + height;
        transform.position = p;
        */

        transform.DOMoveY(_startPosition.y + height, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        /*var position = transform.position;
        position.y = _startPosition.y;
        transform.position = position;
        */
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float size)
    {
        coinCollector.transform.localScale = Vector3.one * size;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }


    #endregion
}
