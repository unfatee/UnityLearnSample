using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneModule : SampleScript
{
    [SerializeField] private GameObject prefab;
    [SerializeField, Range(1, 50)] private int count = 5;
    [SerializeField, Min(0.1f)] private float step = 1f;
    [SerializeField] private Vector3 direction = Vector3.right;

    public override void Use()
    {
        if (prefab == null) return;

        for (int i = 0; i < count; i++)
        {
            Vector3 pos = transform.position + direction * step * i;
            Instantiate(prefab, pos, prefab.transform.rotation);
        }
    }
}
