using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrawer : MonoBehaviour
{
    private KeyCode drawingKey = KeyCode.A;

    public GameObject card;
    public GameObject hand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 키 누르면 핸드에 카드 추가
        if (Input.GetKeyDown(drawingKey))
        {
            Instantiate(card, hand.transform);
        }
    }

}
