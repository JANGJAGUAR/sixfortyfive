using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    private Logic _lastestLogic = Logic.None;
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
        _lastestLogic = Logic.None;
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
        answerSheet.Clear();
        for (int i = 1; i <= 45; i++)
        {
            if(i==numericPart) continue;
            answerSheet.Add(i);
        }
    }

    void Reverse()
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

    void Equal()
    {
        answerSheet.Clear();
        answerSheet.Add(numericPart);
    }

    void MultipleOf()
    {
        for (int i = answerSheet.Count - 1; i >= 0; i--)
        {
            if (answerSheet[i] % numericPart != 0)
            {
                answerSheet.RemoveAt(i);
            }
        }
    }

    void DivisorOf()
    {
        for (int i = answerSheet.Count - 1; i >= 0; i--)
        {
            if (numericPart%answerSheet[i] != 0)
            {
                answerSheet.RemoveAt(i);
            }
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
                _latestOperator = op;
                break;
            case CardType.Logical:
                switch (logic)
                {
                    case Logic.Not:
                        if (_lastestLogic == Logic.None)
                        {
                            _lastestLogic = Logic.Not;
                        }
                        else if (_lastestLogic == Logic.Not)
                        {
                            _lastestLogic = Logic.Not;
                        }
                        else if (_lastestLogic==Logic.Equal)
                        {
                            _lastestLogic = Logic.Not;
                        }
                        else if (_lastestLogic == Logic.Greater)
                        {
                            _lastestLogic = Logic.EqualOrLess;
                        }
                        else if (_lastestLogic == Logic.Less)
                        {
                            _lastestLogic = Logic.EqualOrGreater;
                        }
                        else if (_lastestLogic == Logic.EqualOrLess)
                        {
                            _lastestLogic = Logic.Greater;
                        }
                        else if (_lastestLogic == Logic.EqualOrGreater)
                        {
                            _lastestLogic = Logic.Less;
                        }
                        break;
                    case Logic.Equal:
                        _lastestLogic = Logic.Equal;
                        break;
                    case Logic.Less:
                        _lastestLogic = logic;
                        break;
                    case Logic.Greater:
                        _lastestLogic = logic;
                        break;
                    case Logic.MultipleOf:
                        _lastestLogic = logic;
                        break;
                    case Logic.DivisionOf:
                        _lastestLogic = logic;
                        break;
                }
                break;
        }
        RevelationEventBus.Publish(RevelationEventType.ApplyCardEffect, numericPart, _latestOperator.ToString(), _lastestLogic.ToString());
        ReWriteAnswerSheet();
        onUpdateAnswerSheet.Invoke(answerSheet);
    }

    public void ReWriteAnswerSheet()
    {
        answerSheet.Clear();
        switch (_lastestLogic)
        {
            case Logic.Equal:
                for (int i = 1; i <= 45; i++)
                {
                    if (i == numericPart)
                    {
                        answerSheet.Add(i);    
                    }
                }
                break;
            case Logic.Not:
                for (int i = 1; i <= 45; i++)
                {
                    if (i != numericPart)
                    {
                        answerSheet.Add(i);    
                    }
                }
                break;
            case Logic.None:
                for (int i = 1; i <= 45; i++)
                {
                    answerSheet.Add(i);
                }
                break;
            case Logic.Greater:
                for (int i = 1; i <= 45; i++)
                {
                    if (i > numericPart)
                    {
                        answerSheet.Add(i);
                    }
                }
                break;
            case Logic.Less:
                for (int i = 1; i <= 45; i++)
                {
                    if (i < numericPart)
                    {
                        answerSheet.Add(i);
                    }
                }
                break;
            case Logic.EqualOrGreater:
                for (int i = 1; i <= 45; i++)
                {
                    if (i >= numericPart)
                    {
                        answerSheet.Add(i);
                    }
                }
                break;
            case Logic.EqualOrLess:
                for (int i = 1; i <= 45; i++)
                {
                    if (i <= numericPart)
                    {
                        answerSheet.Add(i);
                    }
                }
                break;
            
        }
    }

    [SerializeField] private GameObject aicheck;

    public void PublishRevelation()
    {
        aicheck.GetComponent<AICheck>().SetTest(answerSheet);
        ReInitializeAnswerSheet();
        onUpdateAnswerSheet.Invoke(answerSheet);
        RevelationEventBus.Publish(RevelationEventType.PublishRevelation, numericPart, _latestOperator.ToString(), _lastestLogic.ToString());
    }
    
    
}
