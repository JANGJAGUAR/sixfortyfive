using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AICheckcopy : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> aiBalls;
    

    [SerializeField]
    private GameObject aiTexts;

    private List<int> _chooseBallList = new List<int>();

    public GameObject answerBall;
    // private List<int> _answerBallList = new List<int>();

    private List<List<int>> test;

    private List<int> _numberList;

    public int nowTurn;


    //화면의 aiball 오브젝트 리스트
    void Start()
    {
        _numberList = new List<int>();
        nowTurn = 0;
        _chooseBallList = new List<int>();
        
        //TODO: 지울 것
        test = new List<List<int>>();
        List<int> test1 = new List<int>();
        List<int> test2 = new List<int>();
        List<int> test3 = new List<int>();
        List<int> test4 = new List<int>();
        List<int> test5 = new List<int>();
        List<int> test6 = new List<int>();
        
        test.Add(test1);
        test.Add(test2);
        test.Add(test3);
        test.Add(test4);
        test.Add(test5);
        test.Add(test6);
        ResetCheck();
        
    }
    

    void Update()
    {
        
    }

    public void UpdateAvailableAnswerNumbers(List<int> answerSheet)
    {
        ResetNumberList();
        //퍼블리쉬 누를때마다 초기화?
        foreach (var answer in answerSheet)
        {
            _numberList.Remove(answer);
        }
        foreach (var noAnswer in _numberList)
        {
            test[nowTurn].Remove(noAnswer);
        }

        // TODO: 확률 출력 (기왕이면 화면에)
        if (test[nowTurn].Count != 0)
        {
            Debug.Log("1/");
            Debug.Log(test[nowTurn].Count);
        }
        else
        {
            Debug.Log("1/45");
        }
        
    }

    void ResetNumberList()
    {
        _numberList.Clear();
        for (int i = 1; i <= 45; i++)
        {
            _numberList.Add(i);
        }
    }

    public int ChooseOne(List<int> predictList, List<int> chooseBalList)
    {
        var random = new Random();
        var randomizedList = predictList.OrderBy(x => random.Next());
        
        //뽑힌거 제거
        foreach (var j in chooseBalList)
        {
            predictList.Remove(j);
        }
        
        //제일 앞에거 출력
        foreach (var i in randomizedList)
        {
            return i;
        }


        // 리스트에 아무것도 없을 때
        List<int> zeroCount = new List<int>();
        for (int i = 1; i <= 45; i++)
        {
            zeroCount.Add(i);
        }
        var randomNumber = zeroCount.OrderBy(x => random.Next());
        foreach (var i in randomNumber)
        {
            return i;
        }
        return 0;
    }

    public void LastBallEnd()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(test[i].Count);
        }


        nowTurn = 0;
        
        
        aiTexts.SetActive(true);

        for (int i = 0; i < 6; i++)
        {
            _chooseBallList.Add(ChooseOne(test[i], _chooseBallList));
        }
        
        var openNumber = 0;
        foreach (var i in _chooseBallList)
        {
            aiBalls[openNumber].SetActive(true);
            aiBalls[openNumber].GetComponent<Balls>().AddBall(i, openNumber);
            openNumber++;
        }

        //TODO: 결과 갖다 쓰기
        Debug.Log(Result(_chooseBallList, answerBall.GetComponent<BallDeck>().openNumberList));
        
        
    }
    
    public int Result(List<int> chooseBallList, List<int> answerBallList)
    {
        

        int cnt = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (chooseBallList[i] == answerBallList[j])
                {
                    //맞은거 빼면서 더하기
                    cnt++;
                }
            }
            
        }

        if (cnt == 5)
        {
            for (int i = 0; i < 6; i++)
            {

                if (answerBallList[6] == chooseBallList[i])

                {
                    return 2;
                }
            }
            
        }
        
        if (cnt == 6)
        {
            return 1;
        }

        if (cnt == 5)
        {
            return 3;
        }

        if (cnt == 4)
        {
            return 4;
        }

        if (cnt == 3)
        {
            return 5;
        }
        return cnt+100;
    }

    public void ResetCheck()
    {
        nowTurn = 0;
        //TODO: 리셋 관련
        aiTexts.SetActive(false);
        foreach (var ball in aiBalls)
        {
            ball.SetActive(false);
        }
        
        _chooseBallList.Clear();
        
        //TODO: 지울 것
        for (int i = 0; i < 6; i++)
        {
            test[i].Clear();
        }
        
    }
}
