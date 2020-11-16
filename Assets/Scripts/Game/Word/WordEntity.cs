using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WordEntity
{
    public string word;
    private int typeIndex;

    public WordDisplay display;
    public WordEntity(string word, WordDisplay display)
    {
        this.word = word;
        typeIndex = 0;
        this.display = display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            display.RemoveWord();
        }

        return wordTyped;
    }

    public void RemoveWord()
    {
        display.RemoveWord();
    }
}
