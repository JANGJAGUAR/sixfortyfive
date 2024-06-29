using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveMerge : MonoBehaviour
{
    [SerializeField] // Test용
    private int _cardNumber;
    
    [SerializeField] // Test용
    private bool _cardOn;

    [SerializeField]
    private Transform cardTransform;

    [SerializeField] 
    private GameObject cardDeck;
    
    void Start()
    {
        _cardOn = false;
    }
    
    void Update()
    {
        
    }

    //TODO: 셔플 깔때 번호 넣어서 실행
    public void AddCard(int cardNumber)
    {
        _cardOn = true;
        _cardNumber = cardNumber;
        
        //TODO: 이미지 = 카드 번호 이미지로 변경

    }

    //TODO: 서진님이 하신거에 붙이기 => (*다른 카드에서*) 손 뗄때마다 이거 실행
    public void ResetPosition(int handLeftCount, int handNumber, bool cardOn)
    {
        if (cardOn)
        {
            _cardNumber = handNumber;
            //TODO: 이미지 = 카드 번호 이미지로 변경
        }
        else
        {
            _cardOn = false;
        }
    }
}
