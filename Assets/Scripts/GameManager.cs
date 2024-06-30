using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int finalScore = 0;
    public bool isClear = false;

    public string sceneName = "MainMenu";

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Dollar))
        {
            AddScore(10);
        }
    }

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // instance
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 씬 바꾸기는 모두 이 친구를 사용할 예정
    // 로딩 화면 구현 시 넣기
    public void ChangeScene(string name)
    {
        sceneName = name;
        SceneManager.LoadScene("LoadingScene");

    }

    public void AddScore(int score)
    {
        finalScore += score;
    }

}
