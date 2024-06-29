using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class FaithBar : MonoBehaviour
{
    public Image faithBarImage;
    public TMP_Text faithText;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        faithBarImage.fillAmount = MoneyManager.Instance.faith / MoneyManager.Instance.maxFaith;
    }
}

