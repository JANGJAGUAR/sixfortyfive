using System.Collections;
using System.Collections.Generic;
using CardScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CardDrawer : MonoBehaviour
{
    [SerializeField] private GameObject[] numericCardPrefabs;
    [SerializeField] private GameObject[] operatorCardPrefabs;
    [SerializeField] private GameObject[] logicCardPrefabs;
    [SerializeField] private GameObject[] cardPrefabs;
    [SerializeField] private Transform numericCardsTable;
    [SerializeField] private Transform logicalCardsTable;

    private List<CardScript> _numericCards = new List<CardScript>();
    private List<CardScript> _operatorCards = new List<CardScript>();
    private List<CardScript> _logicCards =  new List<CardScript>();
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
        DrawCards(10);
    }

    // Update is called once per frame
    void InitializeCards()
    {
        foreach (var card in numericCardPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = Instantiate(card, transform);
                var cardScript = cardObj.GetComponent<CardScript>();
                cardScript.Initialize(this);

                _numericCards.Add(cardScript);
                cardObj.SetActive(false);
            }
        }
        
        foreach (var card in operatorCardPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = Instantiate(card, transform);
                var cardScript = cardObj.GetComponent<CardScript>();
                cardScript.Initialize(this);

                _operatorCards.Add(cardScript);
                cardObj.SetActive(false);
            }
        }

        foreach (var card in logicCardPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = Instantiate(card, transform);
                var cardScript = cardObj.GetComponent<CardScript>();
                cardScript.Initialize(this);

                _logicCards.Add(cardScript);
                cardObj.SetActive(false);
            }
        }
    }


    void DrawCards(int drawNum)
    {
        // for (int i = 0; i < drawNum; i++)
        // {
        //     if (_unusedCards.Count == 0)
        //     {
        //         //Refill
        //         ReShakeCards();
        //     }
        //
        //     var randIdx = Random.Range(0, _unusedCards.Count);
        //     var card = _unusedCards[randIdx];
        //
        //     card.Initialize(this);
        //     card.gameObject.SetActive(true);
        //     card.transform.SetParent(hand.transform, false);
        //
        //     card.transform.localPosition = Vector3.zero;
        //     card.transform.localRotation = Quaternion.identity;
        //
        //     hand.HandArrange();
        //
        //     _unusedCards.RemoveAt(randIdx);
        //     _handCards.Add(card);
        //     if (Input.GetKeyDown(drawingKey))
        //     {
        //         Instantiate(card, hand.transform);
        //         hand.GetComponent<PlayerHand>().HandArrange();
        //     }
        // }
        int numericNeeds = 6;
        int operatorNeeds = 2;
        int logicalNeeds = 2;
        foreach (var card in _handCards)
        {
            switch (card.cardSo.type)
            {
                case CardType.Numeric:
                    numericNeeds--;
                    break;
                case CardType.Operator:
                    operatorNeeds--;
                    break;
                case CardType.Logical:
                    logicalNeeds--;
                    break;
            }
        }

        for (int i = 0; i < numericNeeds; i++)
        {
            var randIdx = Random.Range(0, _numericCards.Count);
            var card = _numericCards[randIdx];
            
            card.Initialize(this);
            card.gameObject.SetActive(true);
            card.transform.SetParent(hand.transform, false);
            
            card.transform.localPosition = Vector3.zero;
            card.transform.localRotation = Quaternion.identity;
            
            hand.HandArrange();
            
            _numericCards.RemoveAt(randIdx);
            _handCards.Add(card);
        }
        
        for (int i = 0; i < operatorNeeds; i++)
        {
            var randIdx = Random.Range(0, _operatorCards.Count);
            var card = _operatorCards[randIdx];
            
            card.Initialize(this);
            card.gameObject.SetActive(true);
            card.transform.SetParent(hand.transform, false);
            
            card.transform.localPosition = Vector3.zero;
            card.transform.localRotation = Quaternion.identity;
            
            hand.HandArrange();
            
            _operatorCards.RemoveAt(randIdx);
            _handCards.Add(card);
        }
        
        for (int i = 0; i < logicalNeeds; i++)
        {
            var randIdx = Random.Range(0, _logicCards.Count);
            var card = _logicCards[randIdx];
            
            card.Initialize(this);
            card.gameObject.SetActive(true);
            card.transform.SetParent(hand.transform, false);
            
            card.transform.localPosition = Vector3.zero;
            card.transform.localRotation = Quaternion.identity;
            
            hand.HandArrange();
            
            _logicCards.RemoveAt(randIdx);
            _handCards.Add(card);
        }
    }

    public void UseHandCard(CardScript cardToUse)
    {
        _handCards.Remove(cardToUse);
        _usedCards.Add(cardToUse);
    }

    public void ReturnCards()
    {
        foreach (var card in _usedCards)
        {
            card.transform.SetParent(transform, false);
            card.gameObject.SetActive(false);

            card.gameObject.GetComponent<CardDrag>().ReInitialize();
            RectTransform rectTransform = card.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = new Vector3(20,20,0);
            
            //_unusedCards.Add(card);

            switch (card.cardSo.type)
            {
                case CardType.Numeric:
                    _numericCards.Add(card);
                    break;
                case CardType.Operator:
                    _operatorCards.Add(card);
                    break;
                case CardType.Logical:
                    _logicCards.Add(card);
                    break;
            }
        }
        
        _usedCards.Clear();
        
        RefillCard();
    }

    public void RefillCard()
    {
        int diff = 10 - _handCards.Count;
        
        DrawCards(diff);
    }

    void ReShakeCards()
    {
        for (int i = _usedCards.Count - 1; i >= 0; i--)
        {
            var card = _usedCards[i];
            _unusedCards.Add(card);
            _usedCards.RemoveAt(i);
        }
    }
}
