using System;
using System.Collections;
using System.Collections.Generic;
using CardScripts;
using RevelationScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NumericRevelation : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //_text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = "Numeric";
        
        RevelationEventBus.Subscribe(RevelationEventType.APPLYCARDEFFECT, ChangeNumericPart);
    }

    private void Update()
    {
        
    }

    void ChangeNumericPart(int numericPart, string str)
    {
        _text.text = $"{numericPart}";
    }
    
    
}
