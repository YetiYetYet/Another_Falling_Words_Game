using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WordEntity
{
    public string word;
    private int typeIndex;
    public WordEntity(string text)
    {
        word = text;
        typeIndex = 0;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if (wordTyped)
        {
            //remove
        }

        return wordTyped;
    }
}
