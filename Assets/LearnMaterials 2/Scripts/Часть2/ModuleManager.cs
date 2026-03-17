using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    [SerializeField] private List<SampleScript> modules = new List<SampleScript>();

    public void UseAll()
    {
        foreach (var module in modules)
        {
            if (module != null)
            {
                module.Use();
            }
        }
    }
}
