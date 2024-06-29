using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class EndObject : MonoBehaviour
{
    public TMP_Text endMessage;
    public TMP_Text finalScore;

    public GameObject continueButton;

    private void Update()
    {
        
    }

    private void Awake()
    {
        endMessage.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1.0f);
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
        continueButton.GetComponent<Button>().interactable = false;
        endMessage.text = "신";
        finalScore.text = "Score : " + GameManager.Instance.finalScore;
        endMessage.color = Color.red;
        StartCoroutine(TextChange());
    }
    
    public void VictoryGame()
    {
        // TODO : 금색 글씨
        endMessage.text = "숭배하라";
        finalScore.text = "Score : " + GameManager.Instance.finalScore;
        endMessage.color = Color.yellow;
        StartCoroutine(TextChange());
    }

    IEnumerator TextChange()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime <= 0.5f)
        {
            endMessage.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1 + 2 * (elapsedTime / 0.5f));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        elapsedTime = 0;
        
        while (elapsedTime <= 0.3f)
        {
            endMessage.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 1 - (elapsedTime / 0.3f));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }
}
