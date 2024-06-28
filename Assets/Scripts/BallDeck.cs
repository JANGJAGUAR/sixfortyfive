using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class BallDeck : MonoBehaviour
{
    public List<int> ballNumberList;
    public List<int> openNumberList;
    private int maxBallNumber = 45;
    private int maxOpenNumber = 7;
    
    [SerializeField]
    private List<GameObject> balls;
    //화면의 ball 오브젝트 리스트

    void Start()
    {
        ballNumberList = new List<int>();
        openNumberList = new List<int>();
        BallReset();
    }

    void Update()
    {
        
    }

    void BallReset()
    {
        ballNumberList.Clear();
        for (int i = 0; i < maxBallNumber; i++)
        {
            ballNumberList.Add(i);
        }
        openNumberList.Clear();
    }

    void BallShuffle()
    {
        var random = new Random();
        var randomizedList = ballNumberList.OrderBy(x => random.Next());

        var openNumber = 0;
        foreach (var i in randomizedList)
        {
            if (openNumberList.Count >= maxOpenNumber) continue;
            openNumberList.Add(i);
            ballNumberList.Remove(i);
            
            // 깔려있는 카드 틀에 새로운 카드를 추가 
            balls[openNumber].GetComponent<Balls>().AddBall(i);
            openNumber++;
        }
        
        foreach (var i in openNumberList)
        {
            Debug.Log(i);
        }
    }
}
