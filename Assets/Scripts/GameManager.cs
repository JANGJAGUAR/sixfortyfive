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
    public void ChangeScene(int scene)
    {
        if (scene == 0)
        {
            sceneName = "TestEndScene";
            SceneManager.LoadScene("LoadingScene");
        }
        else if (scene == 1)
        {
            SceneManager.LoadScene("");
        }
        
    }

    

    // TODO : 간단한 로딩 구현
    // IEnumerator LoadScenes()
    // {
    //     
    // }
}
