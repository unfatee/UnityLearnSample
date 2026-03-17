using System.Collections;
using UnityEngine;

public class TransparentModule : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float targetAlpha = 0.5f;
    [SerializeField, Min(0.1f)] private float duration = 1f;

    public void ActivateModule()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend == null) yield break;

        Color start = rend.material.GetColor("_Color");
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            Color newColor = new Color(start.r, start.g, start.b, Mathf.Lerp(start.a, targetAlpha, t));
            rend.material.SetColor("_Color", newColor);
            yield return null;
        }

        rend.material.SetColor("_Color", new Color(start.r, start.g, start.b, targetAlpha));
    }
}