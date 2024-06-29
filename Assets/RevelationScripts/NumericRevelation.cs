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
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        //_text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = "";
        
        RevelationEventBus.Subscribe(RevelationEventType.ApplyCardEffect, ChangeNumericPart);
        RevelationEventBus.Subscribe(RevelationEventType.PublishRevelation, ChangeNumericPart);
    }

    private void Update()
    {
        
    }

    void ChangeNumericPart(int numericPart, string opStr, string logiStr)
    {
        
        if (opStr.Equals("None"))
        {
            _text.text = $"{numericPart}";    
        }
        else
        {
            _text.text = $"{numericPart}"+opStr;
        }
    }
    
    
}
