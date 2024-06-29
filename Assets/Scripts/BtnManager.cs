using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    //TODO: 메인으로
    private GameObject _frame;

    public int putdownNum=0;
    
    void Start()
    {
        _frame = GameObject.Find("hands");
    }
    
    void Update()
    {
        
    }

    public void IncBtn()
    {
        putdownNum++;
    }
    public void ShuffleBtn()
    {
        _frame.GetComponent<CardDeck>().CardShuffle();
    }
    
    public void PutDownBtn()
    {
        _frame.GetComponent<CardDeck>().CardPutDown(putdownNum);
    }
    
    public void ResetBtn()
    {
        _frame.GetComponent<CardDeck>().CardReset();
    }
    public void HandOutBtn()
    {
        // _frame.GetComponent<CardDeck>().CardPositionReset();
    }
    
}
