using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTemplateProjects.Game
{
    public class WordManager : MonoBehaviour
    {
        
        public List<Word> words;

        public bool hasActiveWord;
        public Word activeWord;

        public void Start()
        {
            AddWord();
        }

        public void AddWord()
        {
            Word word = new Word(WordGenerator.GetRandomWord());
            Debug.Log(word.word);
            
            words.Add(word);
        }

        public void TypeLetter(char letter)
        {
            if (hasActiveWord)
            {
                if (activeWord.GetNextLetter() == letter)
                {
                    activeWord.TypeLetter();
                }
            }
            else
            {
                foreach (var word in words)
                {
                    if (word.GetNextLetter() == letter)
                    {
                        activeWord = word;
                        hasActiveWord = true;
                        word.TypeLetter();
                        break;
                    }
                }
            }

            if (hasActiveWord && activeWord.WordTyped())
            {
                hasActiveWord = false;
                words.Remove(activeWord);
            }
        }
    }
}