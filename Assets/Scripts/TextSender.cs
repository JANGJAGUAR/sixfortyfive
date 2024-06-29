using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSender : MonoBehaviour
{

    public string[] dialogStrings;
    public TextMeshProUGUI textObj;
    
    // Start is called before the first frame update
    void Start()
    {
        TypingManager.instance.Typing(dialogStrings, textObj);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
