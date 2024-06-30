using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class AvailableNumbers : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        for (int i = 1; i <= 45; i++)
        {
            _text.text += $"{i} ";
        }
    }

    public void UpdateAvailableNumbers(List<int> answerSheet)
    {
        _text.text = "";
        for (int i = 1; i <= 45; i++)
        {
            bool isInAnswerSheet = false;
            foreach (int element in answerSheet)
            {
                if (element == i)
                {
                    isInAnswerSheet = true;
                    break;
                }
            }

            string txt;
            if (isInAnswerSheet)
            {
                txt = $"<color=#ffffff>{i}</color > ";
            }
            else
            {
                txt = $"<color=#737373>{i}</color > ";
            }

            _text.text += txt;
        }
    }
}
