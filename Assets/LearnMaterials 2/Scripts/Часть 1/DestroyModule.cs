using System.Collections;
using UnityEngine;

public class DestroyModule : MonoBehaviour
{
    [SerializeField, Min(0f)] private float destroyDelay = 0.5f;
    [SerializeField, Min(0)] private int minimalDestroyingObjectsCount = 0;

    public void ActivateModule()
    {
        StartCoroutine(DestroyRandom());
    }

    private IEnumerator DestroyRandom()
    {
        while (transform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, transform.childCount);
            Destroy(transform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject);
    }
}