using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 positionChange;
    [SerializeField] float duration;

    void MoveBackAndForth(Vector3 moveTo, Vector3 moveFrom)
    {
        transform.DOLocalMove(moveTo, duration).OnComplete(
            () => MoveBackAndForth(moveFrom, moveTo));
    }

    void Start()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + positionChange;

        MoveBackAndForth(endPosition, startPosition);
    }
}

