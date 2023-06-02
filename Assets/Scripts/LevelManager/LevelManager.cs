using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField, BoxGroup("References")] public Transform container;
    [SerializeField, BoxGroup("References")] public List<GameObject> level;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPiecesStart;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPieces;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPiecesEnd;

    [SerializeField, BoxGroup("Pieces config")] public int piecesNumberStart = 1;
    [SerializeField, BoxGroup("Pieces config")] public int piecesNumber = 5;
    [SerializeField, BoxGroup("Pieces config")] public int piecesNumberEnd = 1;
    [SerializeField, BoxGroup("Pieces config")] public float timeBetweenPieces = .3f;

    [ShowNonSerializedField] private int _index;
    [ShowNonSerializedField] private GameObject _currentLevel;
    [ShowNonSerializedField] private List<LevelPieceBase> _spawnedPieces ;
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
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < piecesNumberStart; i++)
        {
            CreateLevelPiece(levelPiecesStart);            
        }       

        for (int i = 0; i < piecesNumber; i++)
        {
            CreateLevelPiece(levelPieces);
        }

        for (int i = 0; i < piecesNumberEnd; i++)
        {
            CreateLevelPiece(levelPiecesEnd);
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
        }
        _spawnedPieces.Add(spawnedPiece);
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
            SpawnNextLevel();
        }
    }
}
