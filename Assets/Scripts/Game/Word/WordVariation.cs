using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordVariation : MonoBehaviour
{
    public TMP_FontAsset[] fonts;
    
    // Start is called before the first frame update
    void Start()
    {
        if (fonts.Length > 0)
        {
            transform.GetComponent<TextMeshProUGUI>().font = fonts[Random.Range(0, fonts.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
