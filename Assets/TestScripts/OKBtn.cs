using System.Collections;
using System.Collections.Generic;
using CardScripts;
using TestScripts;
using UnityEngine;
using UnityEngine.EventSystems;

public class OKBtn : MonoBehaviour, IPointerClickHandler
{
    public NumericInput numericInput;
    public CardTypeDropDown cardTypeDropdown;
    public LogicalDropdown logicalDropdown;
    public OperatorDropdown operatorDropdown;
    private CardType _cardType;
    private Operator _operator;
    private Logic _logic;
    private int _number;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _cardType = cardTypeDropdown.currentCardType;
        _logic = logicalDropdown.currentLogic;
        _operator = operatorDropdown.currentOperator;
        _number = numericInput.currentNumber;
        
        Debug.Log($"CurrentLogic: {_logic}");
        
        CardEventBus.Publish(CardEventType.UseCard, _cardType, _number, _operator, _logic);
    }
}
