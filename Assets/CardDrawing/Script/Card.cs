using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private SpriteRenderer render;
    
    public int cardType = 0;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        // render.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
        cardType = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
