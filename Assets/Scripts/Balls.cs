using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField]
    private int _ballNumber;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddBall(int ballNumber)
    {
        _ballNumber = ballNumber;
        //TODO: 이미지 = 공 번호 이미지로 변경
    }

}
