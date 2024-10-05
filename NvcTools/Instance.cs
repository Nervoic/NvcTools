
using System;
using UnityEngine;
namespace NvcUtils.NvcTools {
public static class Instance
{
    /// <summary>
    /// Initialize instance
    /// </summary>
    /// <typeparam name="T">Component to initialize</typeparam>
    /// <param name="obj">Your gameobject</param>
    /// <returns>Return initialized value</returns>
    public static T Init<T>(GameObject obj) where T : Component {
        return InitComponent<T>(obj, false);
    }
    /// <summary>
    /// Initialize instance
    /// </summary>
    /// <typeparam name="T">Component to initialize</typeparam>
    /// <param name="obj">Your gameobject</param>
    /// <param name="addIfNull">Added this component, if this component is null</param>
    /// <returns>Return initialized value</returns>
    public static T Init<T>(GameObject obj, bool addIfNull) where T : Component {
        return InitComponent<T>(obj, addIfNull);
    }

    private static T InitComponent<T>(GameObject obj, bool addIfNull) where T : Component {
        try {
            T component = obj.GetComponent<T>();
            if(component != null) return component;
            else if(!addIfNull) {
                Debug.Log(typeof(T) + " is null");
                return default;
            } else { 
                component = obj.AddComponent<T>();
                return component;
            }
        } catch(Exception e) {
            Debug.Log(e.Message);
            return default;
        }
    }
}
}
