using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelPieceBaseSetup : ScriptableObject
{
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPiecesStart;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPieces;
    [SerializeField, BoxGroup("References")] public List<LevelPieceBase> levelPiecesEnd;

    [SerializeField, BoxGroup("Pieces config")] public int piecesNumberStart = 1;
    [SerializeField, BoxGroup("Pieces config")] public int piecesNumber = 5;
    [SerializeField, BoxGroup("Pieces config")] public int piecesNumberEnd = 1;
    
    [SerializeField, BoxGroup("Art config")] public ArtManager.ArtType artType;
}
