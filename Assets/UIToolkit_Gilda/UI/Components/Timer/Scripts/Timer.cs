using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : VisualElement
{
    private Label timerLabel;
    private Button timerButton;

    private string format = "hh:mm:ss";

    public string Format
    {
        get => format;
        set => format = value;
    }

    public Timer()
    {
        var template = Resources.Load<VisualTreeAsset>("Timer");
        template.CloneTree(this);

        timerLabel = this.Q<Label>();
        
        RegisterCallback<AttachToPanelEvent>(evt =>
        {
            OnAttach();
        });
        
        RegisterCallback<DetachFromPanelEvent>(evt =>
        {
            OnDetach();
        });
    }

    private void OnAttach()
    {
        Debug.Log("OnAttach");
        
        if (Application.isPlaying)
            Application.onBeforeRender += Update;
        
#if UNITY_EDITOR
        else if (Application.isEditor)
            UnityEditor.EditorApplication.update += Update;
#endif
    }

    private void OnDetach()
    {
        Debug.Log("OnDetach");
        
        if (Application.isPlaying)
            Application.onBeforeRender -= Update;
        
#if UNITY_EDITOR
        else if (Application.isEditor)
            UnityEditor.EditorApplication.update -= Update;
#endif
    }

    private void Update()
    {
        timerLabel.text = DateTime.Now.ToString(Format);
    }
    
    
    public new class UxmlFactory : UxmlFactory<Timer, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription _format = new UxmlStringAttributeDescription
        {
            name = "format",
            defaultValue = "hh:mm:ss"
        };
        
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var format = _format.GetValueFromBag(bag, cc);
            ((Timer) ve).Format = format;
        }
    }
}
