using System.Collections;
using UnityEngine;

public class ScalerModule : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = Vector3.one;
    [SerializeField, Min(0.1f)] private float duration = 1f;

    public void ActivateModule()
    {
        StartCoroutine(Scale());
    }

    private IEnumerator Scale()
    {
        Vector3 start = transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.localScale = Vector3.Lerp(start, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}