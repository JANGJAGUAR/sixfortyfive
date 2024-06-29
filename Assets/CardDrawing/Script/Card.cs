using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardType;
    // Start is called before the first frame update
    void Start()
    {
        cardType = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
