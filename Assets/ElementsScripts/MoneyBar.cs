using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    public Image moneyBarImage;
    public TMP_Text moneyText;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "" + MoneyManager.Instance.money;
    }
}
