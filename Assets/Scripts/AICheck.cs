using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
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

    private List<int> _noList;
    private List<int> _numberList;
    public int nowTurn;
    public int rank;
    public int score;


    //화면의 aiball 오브젝트 리스트
    void Start()
    {
        _noList = new List<int>();
        _numberList = new List<int>();
        
        _chooseBallList = new List<int>();
        //TODO: 지울 것
        test = new List<List<int>>();
        
        ResetCheck();
        nowTurn = -1;
        AiNextTurn();

    }
    

    void Update()
    {
        
    }

    public void SetTest(List<int> list)
    {
        Debug.Log(list.Count);
        Debug.Log(test[nowTurn].Count);
        Debug.Log(nowTurn);
        ResetNumberList();
        foreach (var answer in list)
        {
            _noList.Remove(answer);
        }
        foreach (var noAnswer in _noList)
        {                               
            test[nowTurn].Remove(noAnswer);
        }
        // Debug.Log(_numberList.Count);
        // test[nowTurn] = list;
        Debug.Log(test[nowTurn].Count);
    }
    void ResetNumberList()
    {
        _noList.Clear();
        for (int i = 1; i <= 45; i++)
        {
            _noList.Add(i);
        }
    }

    

    public void AiNextTurn()
    {
        nowTurn++;
        
        
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
            SoundManager.Instance.PlayBallShakeSound();
            openNumber++;
        }

        //TODO: 결과 갖다 쓰기
        Debug.Log(Result(_chooseBallList, answerBall.GetComponent<BallDeck>().openNumberList));
        
        
    }
    
    public int Result(List<int> chooseBallList, List<int> answerBallList)
    {
        rank = 0;
        score = 0;
        
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
                    rank = 2;
                    score = 55000000;
                    
                }
            }
            
        }
        
        if (cnt == 6)
        {
            GameManager.Instance.isClear = true;
            rank = 1;
            score = 2000000000;
        }

        if (cnt == 5 || rank != 2)
        {
            GameManager.Instance.isClear = true;
            rank = 3;
            score = 1500000;
        }

        if (cnt == 4)
        {
            GameManager.Instance.isClear = true;
            rank = 4;
            score = 50000;
        }

        if (cnt == 3)
        {
            GameManager.Instance.isClear = true;
            rank = 5;
            score = 5000;
        }

        if (cnt == 2 || cnt == 1 || cnt == 0)
        {
            GameManager.Instance.isClear = false;
        }
        
        GameManager.Instance.AddScore(score);
        StartCoroutine(PrintResult(rank, score));

        return 0;
    }

    public GameObject rankResult;
    public TMP_Text resultText;
    public TMP_Text scoreText;
    
    IEnumerator PrintResult(int rank, int score)
    {
        // 빰빰빰
        float waitingTime = 0.0f;

        while (waitingTime <= 6.0f)
        {
            waitingTime += Time.deltaTime;
            yield return null;
        }
        
        rankResult.SetActive(true);
        resultText.text = "결과 : " + rank.ToString() + "위";
        scoreText.text = "+ " + score.ToString() + " 점";
        
        if (rank == 0)
        {
            resultText.color = Color.red;
            resultText.text = "결과 : 꼴등";
            scoreText.color = Color.red;
        }

        waitingTime = 0;

        while (waitingTime <= 2.0f)
        {
            waitingTime += Time.deltaTime;
            yield return null;
        }
        
        GameManager.Instance.ChangeScene("TestEndScene");

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
        
        //TODO: 지울 것
        for (int i = 0; i < 6; i++)
        {
            test[i].Clear();
            
            for (int j = 1; j <= 45; j++)
            {
                test[i].Add(j);
            }
        }
        
        
    }
}
