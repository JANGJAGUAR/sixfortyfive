using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AICheck : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> aiBalls;
    

    [SerializeField]
    private GameObject aiTexts;

    private List<int> _chooseBallList = new List<int>();

    public GameObject answerBall;
    // private List<int> _answerBallList = new List<int>();

    private List<List<int>> test;

    public int nowTurn;


    //화면의 aiball 오브젝트 리스트
    void Start()
    {
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
        
        //퍼블리쉬 누를때마다 초기화?
        test[nowTurn].Clear();
        foreach (var answer in answerSheet)
        {
            test[nowTurn].Add(answer);
        }
        
        Debug.Log(test[nowTurn].Count);
        
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

        return 0;
    }

    public void LastBallEnd()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log(test[i].Count);
        }
        
        
        nowTurn = 0;
        //TODO: 지울 것
        // test[.Add(3);
        // test1.Add(3); test1.Add(4);
        // test2.Add(3); test2.Add(4); test2.Add(1);
        // test3.Add(3); test3.Add(4); test3.Add(1); test3.Add(2);
        // test4.Add(3); test4.Add(4); test4.Add(1); test4.Add(2); test4.Add(5); 
        // test5.Add(3); test5.Add(4); test5.Add(1); test5.Add(2); test5.Add(5); 
        
        
        
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
        
        // 맞은 개수 체크
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

        // 순위가 있으면 클리어, 없으면 실패
        // 순위에 따라 돈 추가
        if (cnt == 5)
        {
            for (int i = 0; i < 6; i++)
            {

                if (answerBallList[6] == chooseBallList[i])

                {
                    GameManager.Instance.isClear = true;
                    MoneyManager.Instance.AddMoney(2);
                }
            }
            
        }
        
        if (cnt == 6)
        {
            GameManager.Instance.isClear = true;
            MoneyManager.Instance.AddMoney(1);
        }

        if (cnt == 5)
        {
            GameManager.Instance.isClear = true;
            MoneyManager.Instance.AddMoney(3);
        }

        if (cnt == 4)
        {
            GameManager.Instance.isClear = true;
            MoneyManager.Instance.AddMoney(4);
        }

        if (cnt == 3)
        {
            GameManager.Instance.isClear = true;
            MoneyManager.Instance.AddMoney(5);
        }

        GameManager.Instance.isClear = false;
        return 0;
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
