using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildrenModule : SampleScript
{
    [SerializeField] private Transform target;
    [SerializeField, Range(0.1f, 5f)] private float duration = 1f;

    public override void Use()
    {
        Transform parent = target != null ? target : transform;

        foreach (Transform child in parent)
        {
            StartCoroutine(Shrink(child.gameObject));
        }
    }

    private IEnumerator Shrink(GameObject obj)
    {
        Vector3 startScale = obj.transform.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            obj.transform.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            yield return null;
        }

        Destroy(obj);
    }
}
