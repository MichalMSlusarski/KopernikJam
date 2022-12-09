using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    [SerializeField] Vector3 scaleChange;
    [SerializeField] float duration;

    void ScaleBackAndForth(Vector3 scaleTo, Vector3 scaleFrom)
    {
        transform.DOScale(scaleTo, duration).OnComplete(
            () => ScaleBackAndForth(scaleFrom, scaleTo));
    }
    
    void Start()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale + scaleChange;

        ScaleBackAndForth(newScale, originalScale);
    }
}
