using System.Collections;
using System.Collections.Generic;
using CardScripts;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR;

public class CardDrawer : MonoBehaviour
{
    [SerializeField] private GameObject[] cardPrefabs;
    [SerializeField] private Transform numericCards;
    [SerializeField] private Transform logicalCards;
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
        foreach (var card in cardPrefabs)
        {
            for (int i = 0; i < 3; i++)
            {
                var cardObj = Instantiate(card, transform);
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
                ReShakeCards();
            }

            var randIdx = Random.Range(0, _unusedCards.Count);
            var card = _unusedCards[randIdx];

            card.Initialize(this);
            card.gameObject.SetActive(true);
            card.transform.SetParent(hand.transform, false);

            card.transform.localPosition = Vector3.zero;
            card.transform.localRotation = Quaternion.identity;

            hand.HandArrange();

            _unusedCards.RemoveAt(randIdx);
            _handCards.Add(card);
            if (Input.GetKeyDown(drawingKey))
            {
                Instantiate(card, hand.transform);
                hand.GetComponent<PlayerHand>().HandArrange();
            }
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
            
            _unusedCards.Add(card);
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
