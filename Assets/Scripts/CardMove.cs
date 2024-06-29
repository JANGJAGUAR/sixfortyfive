using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    [SerializeField] // Test용
    private int _cardNumber;
    private int _putCardNumber;
    // private int _handNumber;
    
    [SerializeField] // Test용
    private bool _cardOn;
    [SerializeField] // Test용
    private float _posX;

    private float _posY;
    
    [SerializeField]
    private Transform cardTransform;

    [SerializeField] 
    private GameObject cardDeck;

    [SerializeField] private float startPosX;
    [SerializeField] private float posTermX;
    [SerializeField] private float startPosY;
    
    
    void Start()
    {
        _cardOn = false;
    }
    
    void Update()
    {
        cardTransform.position = new Vector3(_posX, _posY,0);
        
        
    }

    // void ShuffleMove(int 1~10)
    // {
    //     
    // }

    //TODO: 셔플 깔때 번호 넣어서 실행
    public void AddCard(int cardNumber)
    {
        _cardOn = true;
        _cardNumber = cardNumber;
        
        //TODO: 이미지 = 카드 번호 이미지로 변경
        
        StartCoroutine(LerpMove(_putCardNumber));

    }
    
    //TODO: 코루틴으로 Lerp이동(못 하겠음)
    IEnumerator LerpMove(int putCardNumber)
    {
        yield return new WaitForSeconds((float) 0.1 * putCardNumber);
        // Vector3.Lerp();
    }
    

    // //TODO: 서진님이 하신거에 붙이기 => (이 카드에서) 손 뗄때마다 이거 실행
    // void RemoveCard()
    // {
    //     _cardOn = false;
    //     cardDeck.GetComponent<CardDeck>().CardPutDown(_cardNumber);
    //     //TODO: 가운데 구멍 위치로
    //     _posX = 0; _posY = 0;
    // }

    //TODO: 서진님이 하신거에 붙이기 => (*다른 카드에서*) 손 뗄때마다 이거 실행
    public void ResetPosition(int handLeftCount, int handNumber, bool cardOn)
    {
        if (cardOn)
        {
            _posX = startPosX + posTermX * handLeftCount;
            _posY = startPosY;
            _cardNumber = handNumber;
            //TODO: 이미지 = 카드 번호 이미지로 변경
        }
        else
        {
            //TODO: 안보이는 곳
            _posX = -600;
            _posY = startPosY;
            _cardOn = false;
        }
    }

    // public void SetHandNumber(int handNumber)
    // {
    //     _handNumber = handNumber;
    // }
}
