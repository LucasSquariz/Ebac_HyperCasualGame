using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField, BoxGroup("References")] public Transform container;
    [SerializeField, BoxGroup("References")] public List<GameObject> level;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBaseSetup> levelPieceSetups;

    [SerializeField, BoxGroup("Pieces config")] public float timeBetweenPieces = .3f;

    [ShowNonSerializedField] private int _index;
    [ShowNonSerializedField] private GameObject _currentLevel;
    [ShowNonSerializedField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    [ShowNonSerializedField] private LevelPieceBaseSetup _currentSetup;
    private void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
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

    #region PIECES

    private void CreateLevelPieces()
    {        
        ClearSpawnedPieces();

        if (_currentLevel != null)
        {            
            _index++;

            if (_index >= levelPieceSetups.Count)
            {
                ResetIndex();
            }

        }

        _currentSetup = levelPieceSetups[_index];

        for (int i = 0; i < _currentSetup.piecesNumberStart; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesStart);            
        }       

        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
        }

        for (int i = 0; i < _currentSetup.piecesNumberEnd; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesEnd);
        }
    }
    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        } else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.type).gameObject);
        }

        _spawnedPieces.Add(spawnedPiece);
    }

    private void ClearSpawnedPieces()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

    /*IEnumerator CreateLevelPiecesCourotine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece();
            yield return new WaitForSeconds(timeBetweenPieces);
        }
    }*/
    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            CreateLevelPieces();
        }
    }
}
