using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetModule : SampleScript
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField, Min(0.1f)] private float speed = 1f;

    public override void Use()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 start = transform.position;
        float distance = Vector3.Distance(start, targetPosition);
        float duration = distance / speed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(start, targetPosition, t);
            yield return null;
        }

        transform.position = targetPosition;
    }
}
