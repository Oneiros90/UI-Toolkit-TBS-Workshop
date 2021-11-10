using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    void Start()
    {
        var document = GetComponent<UIDocument>();
        var root = document.rootVisualElement;
        var background = root.Q<VisualElement>("Background");

        var title = root.Q<Label>(name: "Title");
        title.text = "Hello World";

        var newButton = new Button();
        newButton.AddToClassList("menuButton");
        newButton.text = "Hello";
        newButton.RegisterCallback<MouseEnterEvent>(evt =>
        {
            Debug.Log("Hello world");
        });
        background.Add(newButton);

    }
}
