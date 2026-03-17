using System.Collections;
using UnityEngine;

public class RotateModule : SampleScript
{
    [SerializeField] private Vector3 angles;
    [SerializeField, Min(1f)] private float speed = 10f;
    [ContextMenu("dddd")]
    public override void Use()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        Vector3 startEuler = transform.eulerAngles;
        Vector3 targetEuler = startEuler + angles;

        float totalAngle = angles.magnitude;
        float duration = totalAngle / speed;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
           
            float x = Mathf.Lerp(startEuler.x, targetEuler.x, t);
            float y = Mathf.Lerp(startEuler.y, targetEuler.y, t);
            float z = Mathf.Lerp(startEuler.z, targetEuler.z, t);

            transform.eulerAngles = new Vector3(x, y, z);
            yield return null;
        }

        transform.eulerAngles = targetEuler;
    }

    private void OnValidate()
    {
        speed = Mathf.Max(1f, speed);
    }
}