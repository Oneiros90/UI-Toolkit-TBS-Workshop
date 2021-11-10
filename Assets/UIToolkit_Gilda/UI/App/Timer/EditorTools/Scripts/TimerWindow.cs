using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TimerWindow : EditorWindow
{
    // Add menu named "Timer Window" to the Window menu
    [MenuItem("Window/Timer Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        TimerWindow window = GetWindow<TimerWindow>();
        window.rootVisualElement.Add(new Timer());
        window.Show();
    }
}
