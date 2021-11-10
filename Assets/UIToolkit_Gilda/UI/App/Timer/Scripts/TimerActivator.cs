using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class TimerActivator : MonoBehaviour
{
    void Start()
    {
        var document = GetComponent<UIDocument>();
        document.rootVisualElement.Clear();
        document.visualTreeAsset = ScriptableObject.CreateInstance<VisualTreeAsset>();

        var timer = new Timer();
        document.rootVisualElement.Add(timer);
    }
}
