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
        if (logicStr.Equals("None"))
        {
            _text.text = "";
            return;
        }
        _text.text = logicStr;
    }
    
    
}
