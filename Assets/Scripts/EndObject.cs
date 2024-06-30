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

    public CanvasGroup canvasGroup;

    public GameObject continueButton;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (GameManager.Instance.isClear)
        {
            SoundManager.Instance.PlayerWinBgm();
            VictoryGame();
        }
        else
        {
            SoundManager.Instance.PlayLoseBgm();
            DefeatGame();
        }
    }

    public void DefeatGame()
    {
        
        continueButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "다시하기";
        continueButton.GetComponent<SceneChangeBtn>().reset = true;
        endMessage.text = "신도가 당신을 저주합니다.";
        endMessage.fontSize = 120;
        finalScore.text = "Score : \n" + GameManager.Instance.finalScore;
        endMessage.color = new Color32(202, 0 ,12, 255);
        StartCoroutine(TextChange());
    }
    
    public void VictoryGame()
    {
        endMessage.text = "신도가 당신을 숭배합니다";
        endMessage.fontSize = 120;
        finalScore.text = "Score : \n" + GameManager.Instance.finalScore;
        endMessage.color = Color.yellow;
        StartCoroutine(TextChange());
    }

    IEnumerator TextChange()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime <= 0.8f)
        {
            canvasGroup.alpha = elapsedTime / 0.8f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        //
        // elapsedTime = 0;
        //
        // while (elapsedTime <= 0.3f)
        // {
        //     endMessage.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 1 - (elapsedTime / 0.3f));
        //     elapsedTime += Time.deltaTime;
        //
        //     yield return null;
        // }

    }
}
