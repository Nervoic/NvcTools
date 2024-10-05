
using System;
using UnityEngine;
namespace NvcUtils.Tools {
public static class Instance
{
    /// <summary>
    /// Initialize instance
    /// </summary>
    /// <typeparam name="T">Component to initialize</typeparam>
    /// <param name="obj">Your gameobject</param>
    /// <returns>Return initialized value</returns>
    public static T InitGet<T>(GameObject obj) where T : Component {
        return InitGetComponent<T>(obj, false);
    }
    /// <summary>
    /// Initialize instance
    /// </summary>
    /// <typeparam name="T">Component to initialize</typeparam>
    /// <param name="obj">Your gameobject</param>
    /// <param name="addIfNull">Added this component, if this component is null</param>
    /// <returns>Return initialized value</returns>
    public static T InitGet<T>(GameObject obj, bool addIfNull) where T : Component {
        return InitGetComponent<T>(obj, addIfNull);
    }

    /// <summary>
    /// Initialize instance, if component is available in scene
    /// </summary>
    /// <typeparam name="T">Component to initialize</typeparam>
    /// <returns>Return initialized value</returns>
    public static T InitFind<T>() where T : Component {
        return InitFindComponent<T>();
    }

    private static T InitGetComponent<T>(GameObject obj, bool addIfNull) where T : Component {
        try {
            T component = obj.GetComponent<T>();
            if(component != null) return component;
            else if(!addIfNull) {
                NullLog<T>();
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

    private static T InitFindComponent<T>() where T : Component {
        try {
            T component = GameObject.FindObjectOfType<T>();
            if(component != null) return component;
            else {
                NullLog<T>();
                return default;
            }
        } catch(Exception e) {
            Debug.Log(e.Message);
            return default;
        }
    }

    private static void NullLog<T>() where T : Component {
        Debug.Log(typeof(T) + " is null");
    }
}
}
