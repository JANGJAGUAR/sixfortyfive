using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    public static TypingManager instance;

    public GameObject howToImage;
    public GameObject Itext;

    public float timeForCharacter;
    public float timeForCharacterFast;

    float characterTime;

    string[] dialogSave;
    TextMeshProUGUI tmpSave;

    public static bool isDialogEnd;

    public bool isTypingEnd = false;
    public int dialogNumber = 0;
    
    float timer;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        timer = timeForCharacter;
        characterTime = timeForCharacter;
    }

    public void Typing(string[] dialogs, TextMeshProUGUI textObj)
    {
        SoundManager.Instance.PlayKeyBoardSound();
        isDialogEnd = false;
        dialogSave = dialogs;
        tmpSave = textObj;
        if (dialogNumber < dialogs.Length)
        {
            if (dialogNumber == 4)
            {
                howToImage.SetActive(true);
                Itext.transform.position += Vector3.up * 100;
            }
            char[] chars = dialogs[dialogNumber].ToCharArray();
            StartCoroutine(Typer(chars, textObj));
        }
        else
        {
            tmpSave.text = "";
            isDialogEnd = true;
            dialogSave = null;
            tmpSave = null;
            dialogNumber = 0;
        }
    }

    IEnumerator Typer(char[] chars, TextMeshProUGUI textObj)
    {
        
        int currentChar = 0;
        int charLength = chars.Length;
        isTypingEnd = false;

        while (currentChar < charLength)
        {
            if (timer >= 0)
            {
                yield return null;
                timer -= Time.deltaTime;
            }
            else
            {
                textObj.text += chars[currentChar].ToString();
                currentChar++;
                timer = characterTime;
            }
        }

        if (currentChar >= charLength)
        {
            isTypingEnd = true;
            dialogNumber++;
            yield break;
        }
    }

    public void GetInputDown()
    {
        if (dialogSave != null)
        {
            if (isTypingEnd)
            {
                tmpSave.text = "";
                Typing(dialogSave, tmpSave);
            }
            else
            {
                characterTime = timeForCharacterFast;
            }
        }
        else
        {
            GameManager.Instance.ChangeScene("MainScene_Edit");
        }
    }

    public void GetInputUp()
    {
        if (dialogSave != null)
        {
            characterTime = timeForCharacter;
        }
    }
}
