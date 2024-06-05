using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Helpers
{
    public static T GetRandomEnumValue<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T));
        var randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(randomIndex);
    }

    public static T CheckOnComponent<T>(Collider collider) where T : Component
    {
        T m_component = collider.transform.root.GetComponent<T>();
        if (m_component != null)
        {
            return m_component;
        }

        T children_component = collider.transform.root.GetComponentInChildren<T>();
        if (children_component != null)
        {
            return children_component;
        }

        return null;
    }   
    
    public static T CheckOnComponent<T>(GameObject go) where T : Component
    {
        if (go == null)
            return null;

        T m_component = go.transform.root.GetComponent<T>();
        if (m_component != null)
        {
            return m_component;
        }

        T children_component = go.transform.root.GetComponentInChildren<T>();
        if (children_component != null)
        {
            return children_component;
        }

        return null;
    }

    public static T CopyComponent<T>(this GameObject destination, T originalComponent) where T: Component
    {
        Type componentType = originalComponent.GetType();

        Component component = destination.GetComponent(componentType);

        if (component == null)
            component = destination.AddComponent(componentType);

        FieldInfo[] fields = componentType.GetFields();
        foreach (FieldInfo item in fields)
        {
            item.SetValue(component, item.GetValue(originalComponent));
        }
        return component as T;
    }

    public static void RandomSortList<T>(List<T> list)
    {
        System.Random random = new System.Random();

        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public static string FormatCoinText(int value)
    {
        if (value >= 10000)
        {
            float formattedValue = value / 1000f;
            return $"{formattedValue.ToString("0.#")}k";
        }
        else
        {
            return value.ToString();
        }
    }

    /// <summary>
    /// Cast a ray to test if Input.mousePosition is over any UI object in EventSystem.current. This is a replacement
    /// for IsPointerOverGameObject() which does not work on Android in 4.6.0f3
    /// </summary>
    public static bool IsPointerOverUIObject()
    {
        // Referencing this code for GraphicRaycaster https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    /// <summary>
    /// Fit to target transform.
    /// </summary>
    /// <param name="destination"></param>
    /// <param name="target"></param>
    public static void RectFitTo(this GameObject destination, RectTransform target)
    {
        var rt = destination.transform as RectTransform;

        rt.pivot = target.pivot;
        rt.position = target.position;
        rt.rotation = target.rotation;

        var s1 = target.lossyScale;
        var s2 = rt.parent.lossyScale;
        rt.localScale = new Vector3(s1.x / s2.x, s1.y / s2.y, s1.z / s2.z);
        rt.sizeDelta = target.rect.size;
        rt.anchorMax = rt.anchorMin = new Vector2(0.5f, 0.5f);
    }

    /// <summary>
    /// First letter uppercase.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string FirstLetterUppercase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    public static void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
