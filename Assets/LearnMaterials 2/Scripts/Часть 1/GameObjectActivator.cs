using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private bool activateMode = true;

    public void ActivateModule()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(activateMode);
        }
    }
}