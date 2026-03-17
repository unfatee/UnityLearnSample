using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModule : SampleScript
{
    [SerializeField] private Vector3 angles;
    [SerializeField, Min(1f)] private float speed = 10f;

    public override void Use()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        Quaternion start = transform.rotation;
        Quaternion target = start * Quaternion.Euler(angles);
        float totalAngle = angles.magnitude;
        float duration = totalAngle / speed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            transform.rotation = Quaternion.Slerp(start, target, t);
            yield return null;
        }

        transform.rotation = target;
    }
}
