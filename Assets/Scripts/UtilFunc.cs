using UnityEngine;
using System.Collections.Generic;

public static class UtilFunc
{
    public static void GetDeepComponents<T>(this GameObject target, List<T> lists)
    {
        T currentComponent = target.GetComponent<T>();
        if(currentComponent != null) lists.Add(currentComponent);
        for (int i = 0; i < target.transform.childCount; i++)
        {
            Transform child = target.transform.GetChild(i);
            child.gameObject.GetDeepComponents<T>(lists);
        }
    }
}