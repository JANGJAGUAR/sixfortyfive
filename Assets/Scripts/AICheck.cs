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

    private List<int> test, test1, test2, test3, test4, test5;

    //화면의 aiball 오브젝트 리스트
    void Start()
    {
        
        _chooseBallList = new List<int>();
        
        //TODO: 지울 것
        test = new List<int>();
        test1 = new List<int>();
        test2 = new List<int>();
        test3 = new List<int>();
        test4 = new List<int>();
        test5 = new List<int>();
        ResetCheck();
        
    }

    void Update()
    {
        
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
        //TODO: 지울 것
        test.Add(3);
        test1.Add(3); test1.Add(4);
        test2.Add(3); test2.Add(4); test2.Add(1);
        test3.Add(3); test3.Add(4); test3.Add(1); test3.Add(2);
        test4.Add(3); test4.Add(4); test4.Add(1); test4.Add(2); test4.Add(5); 
        test5.Add(3); test5.Add(4); test5.Add(1); test5.Add(2); test5.Add(5); 
        
        
        
        aiTexts.SetActive(true);
        
        _chooseBallList.Add(ChooseOne(test, _chooseBallList));
        _chooseBallList.Add(ChooseOne(test1, _chooseBallList));
        _chooseBallList.Add(ChooseOne(test2, _chooseBallList));
        _chooseBallList.Add(ChooseOne(test3, _chooseBallList));
        _chooseBallList.Add(ChooseOne(test4, _chooseBallList));
        _chooseBallList.Add(ChooseOne(test5, _chooseBallList));
        
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
        //TODO: 리셋 관련
        aiTexts.SetActive(false);
        foreach (var ball in aiBalls)
        {
            ball.SetActive(false);
        }
        
        _chooseBallList.Clear();
        
        //TODO: 지울 것
        test.Clear();
        test1.Clear();
        test2.Clear();
        test3.Clear();
        test4.Clear();
        test5.Clear();
    }
}
