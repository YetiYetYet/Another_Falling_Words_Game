using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WordInput : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }

    public void OnTextInput(char ch)
    {
        Debug.Log(ch);
    }
}
