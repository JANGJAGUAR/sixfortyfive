using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndObject : MonoBehaviour
{
    public TMP_Text endMessage;
    public TMP_Text finalScore;

    private void Update()
    {
        
    }

    private void Awake()
    {
        if (GameManager.Instance.isClear)
        {
            VictoryGame();
        }
        else
        {
            DefeatGame();
        }
    }

    public void DefeatGame()
    {
        // TODO: 검은 배경 -> 빨간 글씨
        // 문구 추가
        endMessage.text = "아깝네요";
        finalScore.text = "Score : " + GameManager.Instance.finalScore;
    }
    
    public void VictoryGame()
    {
        // TODO : 하얀 배경 + 파랑 ? 금색 글씨
        endMessage.text = "축하합니다";
        finalScore.text = "Score : " + GameManager.Instance.finalScore;
    }
}
