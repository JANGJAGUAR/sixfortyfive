using RevelationScripts;
using TMPro;
using UnityEngine;

public class LogicalRevelation : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        _text.text = "";
        
        RevelationEventBus.Subscribe(RevelationEventType.ApplyCardEffect, UpdateLogicalPart);
        RevelationEventBus.Subscribe(RevelationEventType.PublishRevelation, UpdateLogicalPart);
    }

    void UpdateLogicalPart(int numeric, string opStr, string logicStr)
    {
        string str = "";
        switch (logicStr)
        {
            case "None":
                str = "None";
                break;
            case "Greater":
                str = ">";
                break;
            case "EqualOrGreater":
                str = ">=";
                break;
            case "Less":
                str = "<";
                break;
            case "EqualOrLess":
                str = "<=";
                break;
            case "MultipleOf":
                str = "Multiple of ";
                break;
            case "DivisonOf":
                str = "Factor of ";
                break;
            case "Not":
                str = "!";
                break;
            case "Equal":
                str = "=";
                break;
        }

        _text.text = str;
    }
    
    
}
