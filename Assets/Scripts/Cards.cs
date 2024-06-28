using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CardType
{
    None,
    Number,
    Operators,
    Proposition
}

public class Cards //  : MonoBehaviour
{
    private int _cardNumber;

    public Cards(int cardNumber)
    {
        _cardNumber = cardNumber;
    }
    
    


}
