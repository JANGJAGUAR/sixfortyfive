using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class CardDeck : MonoBehaviour
{
    public List<int> deckNumberList;
    public List<int> handNumberList;
    public List<int> trashNumberList;

    [SerializeField]
    private List<GameObject> handCards;
    //손패의 카드 오브젝트 리스트 

    [SerializeField]
    private int maxCardNumber = 30;
    [SerializeField]
    private int handCardNumber = 10;

    //지금 손의 카드 개수
    private int _nowHandNumber;
    
    void Start()
    {
        
        deckNumberList = new List<int>();
        handNumberList = new List<int>();
        trashNumberList = new List<int>();
        CardReset();
        
    }
    
    void Update()
    {
        //TODO: 손뗄때마다 set보내주기
        // if ()
        // {
        //     CardPositionReset();
        // }
    }
    
    //시작 시, 혹은 셔플 시 카드를 섞고 위의 (10)장만 꺼내서 리스트에 넣음
    public void CardShuffle() //TODO: add param, 일정개수만 셔플로 추가 할수도 있음
    {
        var random = new Random();
        var randomizedList = deckNumberList.OrderBy(x => random.Next());
        
        foreach (var i in randomizedList)
        {
            if (handNumberList.Count >= handCardNumber) continue;
            handNumberList.Add(i);
            deckNumberList.Remove(i);
            
            // 깔려있는 카드 틀에 새로운 카드를 추가 
            handCards[_nowHandNumber].GetComponent<CardMove>().AddCard(i);
            _nowHandNumber++;
        }
        
        foreach (var i in handNumberList)
        {
            Debug.Log(i);
        }
        
        HandPositionReset();
        
    }
    
    //카드를 내려놓음, 카드 번호를 삭제함, 동시에 손패를 리셋
    public void CardPutDown(int putNumber) //TODO: add param
    {
        handNumberList.Remove(putNumber);
        trashNumberList.Add(putNumber);
        _nowHandNumber--;
        
        
        foreach (var i in trashNumberList)
        {
            Debug.Log(i);
        }
        
        HandPositionReset();
    }

    //손패를 리셋, 카드 개수만큼은 재설정을 하고 나머지는 이상한곳으로 보내기
    public void HandPositionReset()
    {
        for (int i = 0; i < handCardNumber; i++)
        {
            if (i < handNumberList.Count)
            {
                handCards[i].GetComponent<CardMove>().ResetPosition(i, handNumberList[i], true);
            }
            else
            {
                handCards[i].GetComponent<CardMove>().ResetPosition(i, 0, false);
            }
            
        }
    } 
    

    //아예 게임을 새로 시작
    public void CardReset()
    {
        _nowHandNumber = 0;
        
        // Deck Reset
        deckNumberList.Clear();
        for (int i = 0; i < maxCardNumber; i++)
        {
            deckNumberList.Add(i);
        }
        
        // Hand, Trash Reset
        handNumberList.Clear();
        trashNumberList.Clear();
    }
}
