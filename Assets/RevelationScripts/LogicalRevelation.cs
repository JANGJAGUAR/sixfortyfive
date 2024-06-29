using RevelationScripts;
using TMPro;
using UnityEngine;

public class LogicalRevelation : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _text.text = "Logical";
        
        RevelationEventBus.Subscribe(RevelationEventType.APPLYCARDEFFECT, UpdateLogicalPart);
    }

    void UpdateLogicalPart(int numeric, string str)
    {
        _text.text = str;
    }
    
    
}
