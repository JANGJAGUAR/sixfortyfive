using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AICheck : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> aiBalls;
    //화면의 aiball 오브젝트 리스트
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int ChooseOne(List<int> predictList)
    {
        var random = new Random();
        var randomizedList = predictList.OrderBy(x => random.Next());
        
        foreach (var i in randomizedList)
        {
            return i;
        }
        return 0;
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
                    cnt++;
                }
            }
            
        }

        if (cnt == 5)
        {
            for (int i = 0; i < 6; i++)
            {
                if (answerBallList[6] == answerBallList[i])
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
        return 0;
    }
}
