using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WordManager : MonoBehaviour
    {
        public TextAsset sourceTextFile;
        public List<string> copyWordsList;
        public List<string> wordsList;
        
        public List<WordEntity> wordEntitys;
        
        public bool hasActiveWord;
        public WordEntity activeWord;

        public void Start()
        {
            wordsList = new List<string>(WordGenerator.GetWordListFromTextAsset(sourceTextFile, true));
            copyWordsList = new List<string>(wordsList);
            
            AddRandomWord();
            AddRandomWord();
        }
        
        
        public void AddRandomWord()
        {
            WordEntity word = new WordEntity(WordGenerator.GetRandomWordFromList(wordsList, true));
            wordEntitys.Add(word);
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
                foreach (var word in wordEntitys)
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
                wordEntitys.Remove(activeWord);
            }
        }
    }
}