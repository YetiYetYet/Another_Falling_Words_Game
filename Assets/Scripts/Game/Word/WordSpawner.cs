using System;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;


namespace Game
{
    public class WordSpawner : MonoBehaviour
    {
        public GameObject wordPrefab;
        public RectTransform canvas;
        public Transform target;
        public float spawnOffset;

        public WordDisplay SpawnWord()
        {
            Vector3 position = GeTRandomPositionArroundScreen();
            
            GameObject wordObj = Instantiate(wordPrefab, position, transform.rotation);
            wordObj.transform.SetParent(transform, false);
            WordDisplay wordDisplay = wordObj.GetComponent <WordDisplay>();
            wordDisplay.target = target;
            
            return wordDisplay;
        }

        public Vector3 GeTRandomPositionArroundScreen()
        {
            var rect = canvas.rect;
            float width = rect.width / 2;
            float height = rect.height / 2;

            float positionX = Random.Range(-width, width);
            float positionY = Random.Range(-height, height);

            int dir = Random.Range(0, 4);
            
            switch (dir)
            {
                case 0: // Top
                    positionY = height + spawnOffset;
                    break;
                case 1: // Bot
                    positionY = -height - spawnOffset;
                    break;
                case 2: // Left
                    positionX = -width - spawnOffset;
                    break;
                case 3: // Right
                    positionX = width + spawnOffset;
                    break;
            }
            
            return new Vector3(positionX, positionY, 0f);
        }
    }
}
