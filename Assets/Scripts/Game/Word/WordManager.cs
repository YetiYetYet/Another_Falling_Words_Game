using System.Collections.Generic;
using Audio;
using UnityEngine;

namespace Game
{
    public class WordManager : MonoBehaviour
    {
        public TextAsset sourceTextFile;
        public List<string> copyWordsList;
        public List<string> wordsList;

        public WordSpawner wordSpawner;
        public Player player;
        
        public List<WordEntity> wordEntitys;

        public bool hasActiveWord;
        public WordEntity activeWord;

        public void Start()
        {
            Time.timeScale = 1;
            wordsList = new List<string>(WordGenerator.GetWordListFromTextAsset(sourceTextFile, true));
            copyWordsList = new List<string>(wordsList);
        }
        
        
        public void AddRandomWord()
        {
            WordEntity word = new WordEntity(WordGenerator.GetRandomWordFromList(wordsList, true),
                wordSpawner.SpawnWord());
            wordEntitys.Add(word);
        }

        
        public void TypeLetter(char letter)
        {
            if (hasActiveWord)
            {
                if (activeWord.GetNextLetter() == letter)
                {
                    player.ShootBullet(activeWord.display.transform);
                    player.AddScore();
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
                        player.ShootBullet(activeWord.display.transform);
                        player.AddScore();
                        word.TypeLetter();
                        break;
                    }
                }
            }

            if (hasActiveWord && activeWord.WordTyped())
            {
                hasActiveWord = false;
                AudioManager.Instance.Play("Damage");
                wordEntitys.Remove(activeWord);
            }
        }

        public void RemoveWord(string wordName)
        {
            for(int i = 0; i < wordEntitys.Count; i++)
            {
                if (wordEntitys[i].word == wordName)
                {
                    if (wordEntitys[i] == activeWord) hasActiveWord = false;
                    wordEntitys[i].display.RemoveWord();
                    wordEntitys.Remove(wordEntitys[i]);
                }
            }
            AudioManager.Instance.Play("Damage");
        }
    }
}