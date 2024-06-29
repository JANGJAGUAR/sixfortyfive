using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TurnManager : MonoBehaviour
{
    public int Turn;

    
    [SerializeField] private GameObject selectObject;
    [SerializeField] private GameObject tableObject;
    
    [SerializeField] private GameObject nextTurnBtn;
    [SerializeField] private GameObject publishBtn;


    [SerializeField] private float believerTime;
    [SerializeField] private float ballWaitingTime;
    
    private Vector3 _selectOriginPosition;
    [SerializeField] private float xMove;

    [SerializeField] private GameObject balldeck;
    [SerializeField] private GameObject aicheck;
    
    // private int we
    
    void Start()
    {
        SoundManager.Instance.PlayBGM();
        _selectOriginPosition = selectObject.transform.position;
        selectObject.SetActive(false);
        publishBtn.SetActive(false);
        nextTurnBtn.SetActive(false);
        StartCoroutine(StartFunc());
        
        //TODO: 씬 바뀌면 바로 시작
    }

    IEnumerator StartFunc()
    {
        yield return new WaitForSeconds(1.0f);
        StartTurn();
    }
    
    void Update()
    {
        
    }

    public void NextTurn()
    {
        Turn++;
        if (Turn <=6)
        {
            SoundManager.Instance.PlayChooseNextBallSound();
        }
        
        aicheck.GetComponent<AICheck>().AiNextTurn();
        
        if (Turn > 6)
        {
            aicheck.GetComponent<AICheck>().LastBallEnd();
            
            selectObject.SetActive(false);
            tableObject.SetActive(false);
            publishBtn.SetActive(false);
            nextTurnBtn.SetActive(false);
            
        }
        
        selectObject.transform.position = _selectOriginPosition + new Vector3(xMove*(Turn-1), 0, 0);
    }

    public void ResetTurn()
    {
        Turn = 1;
        balldeck.GetComponent<BallDeck>().BallReset();
        aicheck.GetComponent<AICheck>().ResetCheck();
        tableObject.SetActive(true);
    }

    public void StartTurn()
    {
        ResetTurn();
        
        //TODO: 신도 오는거 기다렸다가
        StartCoroutine(WaitingBeliever());
        
        
        //TODO: 섞는거 끝나면 서클 띄우고 시작
        StartCoroutine(WaitingBall());
        
    }
    
    IEnumerator WaitingBeliever()
    {   
        
        yield return new WaitForSeconds(believerTime*2/3);
        SoundManager.Instance.PlayBallShakeSound();
        yield return new WaitForSeconds(believerTime*1/3);
        balldeck.GetComponent<BallDeck>().BallShuffle();
        
        
        
    }

    IEnumerator WaitingBall()
    {
        yield return new WaitForSeconds(believerTime + ballWaitingTime);
        selectObject.SetActive(true);
        publishBtn.SetActive(true);
        nextTurnBtn.SetActive(true);
        selectObject.transform.position = _selectOriginPosition;
    }

}
