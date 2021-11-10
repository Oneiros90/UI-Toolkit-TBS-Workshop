using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerMonoBehaviour : MonoBehaviour
{

    [CustomEditor(typeof(TimerMonoBehaviour))]
    public class TimerInspector : Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var inspector = new VisualElement();

            var timer = new Timer();
            inspector.Add(timer);
            
            return inspector;
        }
    }
    
}
