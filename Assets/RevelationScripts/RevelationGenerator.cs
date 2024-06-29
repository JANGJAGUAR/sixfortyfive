using System;
using System.Collections;
using System.Collections.Generic;
using CardScripts;
using Microsoft.Win32.SafeHandles;
using RevelationScripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RevelationGenerator : MonoBehaviour
{
    private Operator _latestOperator = Operator.None;
    public UnityEvent<List<int>> onUpdateAnswerSheet;
    public List<int> answerSheet = new List<int>();
    public int numericPart;
    private void Start()
    {
        InitializeAnswerSheet();
        CardEventBus.Subscribe(CardEventType.UseCard, ApplyCard);
    }

    void InitializeAnswerSheet()
    {
        for (int i = 1; i <= 45; i++)
        {
            answerSheet.Add(i);
        }
    }

    void ReInitializeAnswerSheet()
    {
        answerSheet.Clear();
        for (int i = 1; i <= 45; i++)
        {
            answerSheet.Add(i);
        }

        numericPart = 0;
        _latestOperator = Operator.None;
    }

    void GreaterThan()
    {
        for (int i = answerSheet.Count - 1; i >= 0; i--)
        {
            if (answerSheet[i] <= numericPart)
            {
                answerSheet.RemoveAt(i);
            }
        }
    }

    void LessThan()
    {
        for (int i = answerSheet.Count - 1; i >= 0; i--)
        {
            if (answerSheet[i] >= numericPart)
            {
                answerSheet.RemoveAt(i);
            }
        }
    }

    void Not()
    {
        List<int> tmpAnswerSheet = new List<int>();

        for (int i = 1; i <= 45; i++)
        {
            bool isRemove = false;
            foreach (var element in answerSheet)
            {
                if (i == element)
                {
                    isRemove = true;
                    break;
                }
            }

            if (!isRemove)
            {
                tmpAnswerSheet.Add(i);
            }
        }
        
        answerSheet.Clear();
        answerSheet = tmpAnswerSheet;

    }

    void MultipleOf()
    {
        foreach (var element in answerSheet)
        {
            if (element % numericPart != 0)
            {
                answerSheet.Remove(element);
            }
        }
    }

    void DivisorOf()
    {
        foreach (var element in answerSheet)
        {
            if (numericPart % element != 0)
            {
                answerSheet.Remove(element);
            }
        }
    }

    void DebugAnswerSheet()
    {
        string debugStr = "In the answerSheet: ";
        foreach (var element in answerSheet)
        {
            debugStr += $"{element}, ";
        }
        Debug.Log(debugStr);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(1800, 100, 100, 100), "Not"))
        {
            Not();
            onUpdateAnswerSheet.Invoke(answerSheet);
        }

        if (GUI.Button(new Rect(1800, 200, 100, 100), "Greater Than"))
        {
            GreaterThan();
            onUpdateAnswerSheet.Invoke(answerSheet);
        }

        if (GUI.Button(new Rect(1800, 300, 100, 100), "Less Than"))
        {
            LessThan();
            onUpdateAnswerSheet.Invoke(answerSheet);
        }
        
        
        if (GUI.Button(new Rect(1800, 400, 100, 100), "Publish"))
        {
            onUpdateAnswerSheet.Invoke(answerSheet);
        }
    }

    void ApplyCard(CardType cardType, int number, Operator op, Logic logic)
    {
        switch (cardType)
        {
            case CardType.Numeric:
                switch (_latestOperator)
                {
                    case Operator.None:
                    case Operator.Plus:
                        numericPart += number;
                        
                        break;
                    case Operator.Minus:
                        numericPart -= number;
                        break;
                    case Operator.Multiply:
                        numericPart *= number;
                        break;
                    case Operator.Divide:
                        numericPart /= number;
                        break;
                }
                
                if (numericPart > 99) numericPart = 99;
                if (numericPart < 0) numericPart = 0;

                _latestOperator = Operator.None;
                break;
            case CardType.Operator:
                //if (_latestOperator != Operator.None) return;
                
                _latestOperator = op;
                
                break;
            case CardType.Logical:
                switch (logic)
                {
                    case Logic.Not:
                        Not();
                        break;
                    case Logic.Less:
                        LessThan();
                        break;
                    case Logic.Greater:
                        GreaterThan();
                        break;
                    case Logic.MultipleOf:
                        MultipleOf();
                        break;
                    case Logic.DivisionOf:
                        DivisorOf();
                        break;
                }
                break;
        }
        
        RevelationEventBus.Publish(RevelationEventType.ApplyCardEffect, numericPart, _latestOperator.ToString(), logic.ToString());
        onUpdateAnswerSheet.Invoke(answerSheet);
    }

    public void PublishRevelation()
    {
        ReInitializeAnswerSheet();
        onUpdateAnswerSheet.Invoke(answerSheet);
        RevelationEventBus.Publish(RevelationEventType.PublishRevelation, numericPart, _latestOperator.ToString(), "None");
    }
}
