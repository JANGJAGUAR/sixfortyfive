using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
    public int Turn;

    
    [SerializeField] private Transform selectTransform;
    private Vector3 _selectOriginPosition;
    [SerializeField] private float xMove;
    
    // private int we
    
    void Start()
    {
        Turn = 1;
        _selectOriginPosition = selectTransform.position;
    }
    
    void Update()
    {
        
    }

    public void NextTurn()
    {
        Turn++;
        if (Turn > 6)
        {
            Turn = 1;
        }
        
        selectTransform.position = _selectOriginPosition + new Vector3(xMove*(Turn-1), 0, 0);
    }
    
}
