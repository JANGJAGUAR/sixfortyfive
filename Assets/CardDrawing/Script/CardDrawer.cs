using System.Collections;
using System.Collections.Generic;
using CardScripts;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR;

public class CardDrawer : MonoBehaviour
{
    [SerializeField] private GameObject[] cardPrefabs;
    private List<CardScript> _unusedCards = new List<CardScript>();
    private List<CardScript> _handCards = new List<CardScript>();
    private List<CardScript> _usedCards = new List<CardScript>();
    private KeyCode drawingKey = KeyCode.A;

    public GameObject card;
    public PlayerHand hand;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeCards();
        DrawCards(5);
    }

    // Update is called once per frame
    void Update()
    {
        // 키 누르면 핸드에 카드 추가
        //TODO: 게임 시작시 자동으로 변경
        // if (Input.GetKeyDown(drawingKey))
        // {
        //     Instantiate(card, hand.transform);
        //     //Debug.Log($"WorldPos: {card.transform.position}, LocalPos: {card.transform.localPosition}");
        //     hand.HandArrange();
        // }
    }

    void InitializeCards()
    {
        foreach (var card in cardPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = Instantiate(card);
                var cardScript = cardObj.GetComponent<CardScript>();
                cardScript.Initialize(this);

                _unusedCards.Add(cardScript);
                cardObj.SetActive(false);
            }
        }
    }
    

    void DrawCards(int drawNum)
    {
        for (int i = 0; i < drawNum; i++)
        {
            if (_unusedCards.Count == 0)
            {
                //Refill
            }
            
            var randIdx = Random.Range(0, _unusedCards.Count);
            var card = _unusedCards[randIdx];
            
            card.gameObject.SetActive(true);
            card.transform.SetParent(hand.transform, false);
            
            card.transform.localPosition = Vector3.zero;
            card.transform.localRotation = Quaternion.identity;
            
            hand.HandArrange();
            
            _unusedCards.RemoveAt(randIdx);
            _handCards.Add(card);
        }
    }

    public void UseHandCard(CardScript cardToUse)
    {
        _handCards.Remove(cardToUse);
        _usedCards.Add(cardToUse);
    }
}
