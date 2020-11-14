using System;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;


namespace Game
{
    public class WordSpawner : MonoBehaviour
    {
        public GameObject wordPrefab;
        public Canvas canvas;

        private Vector2 _screenBounds;

        private void Start()
        {
            Assert.IsNotNull(Camera.main);
            
        }

        public WordDisplay SpawnWord()
        {
            RectTransform rectTransform = canvas.GetComponent<RectTransform>();
            //positionX = 
            
            GameObject wordObj = Instantiate(wordPrefab, transform);
            WordDisplay wordDisplay = wordObj.GetComponent <WordDisplay>();
            return wordDisplay;
        }
    }
}
