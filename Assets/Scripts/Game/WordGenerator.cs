using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Game
{
    public class WordGenerator
    {
        private static string[] wordTestList = {"sidewalk", "robin", "three", "protect", "periodic" };
        
        public static List<string> GetWordListFromTextAsset(TextAsset textAsset, bool removeDuplicate)
        {
            Assert.IsNotNull(textAsset);
            List<string> wordList = new List<string>(Regex.Split(textAsset.text, @"\s").Where(s => s != ""));
            if (removeDuplicate) wordList = wordList.Distinct().ToList();
            return wordList;
        }
        
        public static List<string> GetWordListFromPathFile(string path, bool removeDuplicate)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            Assert.IsNotNull(textAsset);
            List<string> wordList = new List<string>(Regex.Split(textAsset.text, @"\s").Where(s => s != ""));
            if (removeDuplicate) wordList = wordList.Distinct().ToList();
            return wordList;
        }

        public static string GetRandomWordFromList(List<string> wordList, bool removeWordFromList)
        {
            Assert.AreNotEqual(0, wordList.Count);
            int randomIndex = Random.Range(0, wordList.Count);
            string randomWord = wordList[randomIndex];
            
            if(removeWordFromList)
                wordList.RemoveAt(randomIndex);
            
            return randomWord;
        }
        
        public static string GetRandomTestWord()
        {
            int randomIndex = Random.Range(0, wordTestList.Length);
            string randomWord = wordTestList[randomIndex];

            return randomWord;
        }
    }
}