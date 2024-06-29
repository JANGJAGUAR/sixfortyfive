using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
    public int Turn;

    
    [SerializeField] private GameObject selectObject;
    private Vector3 _selectOriginPosition;
    [SerializeField] private float xMove;

    [SerializeField] private GameObject _balldeck;

    [SerializeField] private GameObject _aicheck;
    
    // private int we
    
    void Start()
    {
        
        _selectOriginPosition = selectObject.transform.position;
        selectObject.SetActive(false);
        // StartTurn();
        //TODO: 씬 바뀌면 바로 시작
    }
    
    void Update()
    {
        
    }

    public void NextTurn()
    {
        Turn++;
        if (Turn > 6)
        {
            _aicheck.GetComponent<AICheck>().LastBallEnd();
            selectObject.SetActive(false);
        }
        
        selectObject.transform.position = _selectOriginPosition + new Vector3(xMove*(Turn-1), 0, 0);
    }

    public void ResetTurn()
    {
        Turn = 1;
        _balldeck.GetComponent<BallDeck>().BallReset();
        _aicheck.GetComponent<AICheck>().ResetCheck();
    }

    public void StartTurn()
    {
        ResetTurn();
        //TODO: 신도 오는거 기다렸다가
        
        _balldeck.GetComponent<BallDeck>().BallShuffle();
        //TODO: 섞는거 끝나면 서클 띄우고 시작
        
        selectObject.SetActive(true);
        selectObject.transform.position = _selectOriginPosition;
    }

}
