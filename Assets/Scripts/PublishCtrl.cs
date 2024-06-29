// using System;
// using System.Collections;
// using System.Collections.Generic;
// using RevelationScripts;
// using UnityEngine;
//
// public class PublishCtrl : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject aicheck;
//
//     // private List<int> _answer;
//     private List<int> _noList;
//     private List<int> _numberList;
//     private void Start()
//     {
//         // _answer = new List<int>();
//         _noList = new List<int>();
//         _numberList = new List<int>();
//     }
//
//     // public void UpdateAvailableAnswerNumbers(List<int> answerSheet)
//     // {
//     // _answer.Clear();
//     // foreach (var ans in answerSheet)
//     // {
//     //     _answer.Add(ans);
//     // }
//     //
//     // 1~45 만들고
//     ResetNumberList();
//     foreach (var answer in answerSheet)
//     {
//         _noList.Remove(answer);
//     }
//     foreach (var noAnswer in _noList)
//     {                               
//         _numberList.Remove(noAnswer);
//     }
//     Debug.Log(_numberList.Count);
//     //     
//     // }
//
//     public void PubBtn()
//     {
//         // aicheck.GetComponent<AICheck>().SetTest(_numberList);
//         
//     }
//
//     public void PubReset()
//     {
//         _numberList.Clear();
//         for (int i = 1; i <= 45; i++)
//         {
//             _numberList.Add(i);
//         }
//     }
//
//     void ResetNumberList()
//     {
//         _noList.Clear();
//         for (int i = 1; i <= 45; i++)
//         {
//             _noList.Add(i);
//         }
//     }
//
//     // public void UpdateAnswers(List<int> list)
//     // {
//     //     // Debug.Log(answerSheet.Count);
//     //     ResetNumberList();
//     //     //퍼블리쉬 누를때마다 초기화?
//     //     foreach (var answer in list)
//     //     {
//     //         _noList.Remove(answer);
//     //         // Debug.Log(_noList.Count);
//     //     }
//     //     foreach (var noAnswer in _noList)
//     //     {                               
//     //         test[nowTurn].Remove(noAnswer);
//     //     }
//     //
//     //     // Debug.Log(nowTurn);
//     //     // Debug.Log(test[nowTurn].Count);
//     //     // Debug.Log(test[nowTurn].Count);
//     //     //
//     //     // // TODO: 확률 출력 (기왕이면 화면에)
//     //     // if (test[nowTurn].Count != 0)
//     //     // {
//     //     //     // Debug.Log("1/");
//     //     //     // Debug.Log(test[nowTurn].Count);
//     //     // }
//     //     // else
//     //     // {
//     //     //     // Debug.Log("1/45");
//     //     // }
//     //     
//     // }
//
//     
// }
