using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    [SerializeField, BoxGroup("References")]public List<Transform> positions;

    [SerializeField, BoxGroup("Moviment config")] public float duration = 1f;

    [ShowNonSerializedField] private int _index;

    private void Start()
    {
        transform.position = positions[0].transform.position;
        NextIndex();
        StartCoroutine(StartMoviment());
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }
    IEnumerator StartMoviment()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while(time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time/duration));
                time += Time.deltaTime;
                yield return null;
            }
            NextIndex();


            time = 0;
            yield return null;
        }
    }
}
