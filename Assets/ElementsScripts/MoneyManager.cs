using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoneyManager : MonoBehaviour
{
    public int money = 0;
    public float faith = 15.0f;

    public float maxFaith = 100.0f;

    public Canvas canvas;
    public GameObject deltaText;
    
    // 일단 직접 입력
    public Vector3 moneyDeltaTextPosition = Vector3.zero; 
    public Vector3 faithDeltaTextPosition = Vector3.zero;

    public static MoneyManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // 한 신도에 한 씬을 쓸 경우 아래 주석 풀기
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 해제하여 사용
    // 등수를 인자로 받아요
    public void AddMoney(int rank)
    {
        // 등수에 따른 차등 보상, 수치 변경 가능
        if (rank == 1)
        {
            CreateDeltaText(0, 1000);
        }
        else if (rank == 2)
        {
            CreateDeltaText(0, 500);
        }
        else if (rank == 3)
        {
            CreateDeltaText(0, 300);
        }
        else if (rank == 4)
        {
            CreateDeltaText(0, 100);
        }
        else if (rank == 5)
        {
            CreateDeltaText(0, 10);
        }
        else
        {
            return;
        }
    
    }

    public void CreateDeltaText(int type, float delta)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-15, 16), Random.Range(-15, 16), 0);
        Vector3 spawnPosition = Vector3.zero;
        // type = 0 : money, type = 1 : faith
        if (type == 0)
        {
            money += (int) delta;
            spawnPosition = moneyDeltaTextPosition + randomPosition;
        }
        else
        {
            faith += delta;
            spawnPosition = faithDeltaTextPosition + randomPosition;
        }

        GameObject deltaTxt = Instantiate(deltaText, spawnPosition, Quaternion.identity, canvas.transform);
        deltaTxt.GetComponent<TMP_Text>().text = delta.ToString();
    }
    
}
