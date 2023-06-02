using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField, BoxGroup("References")] public Transform container;
    [SerializeField, BoxGroup("References")] public List<GameObject> level;

    [ShowNonSerializedField] private int _index;
    [ShowNonSerializedField] private GameObject _currentLevel;
    private void Awake()
    {
        SpawnNextLevel();
    }

    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if(_index >= level.Count)
            {
                ResetIndex();
            }
        }
        _currentLevel = Instantiate(level[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetIndex()
    {
        _index = 0;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            SpawnNextLevel();
        }
    }
}
