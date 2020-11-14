using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public WordManager wordManager;
    
    // Update is called once per frame
    void Start()
    {
        Keyboard.current.onTextInput += OnTextInput;
    }

    public void OnTextInput(char ch)
    {
        
        wordManager.TypeLetter(ch);
    }
}
