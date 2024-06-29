using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 startPosition;

    private Vector3 mousePosition;
    private Vector3 worldPosition;

    public Card card;

    private bool _draggable = true;

    public GameObject Table1;
    public GameObject Table2;
    
    // Start is called before the first frame update
    void Start()
    {
        card = GetComponent<Card>();
        
        Table1 = GameObject.Find("Type1");
        Table2 = GameObject.Find("Type2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnMouseEnter()
    // {
    //     startPosition = transform.position;
    //     transform.position += Vector3.up * 15.0f; 
    // }
    //
    // private void OnMouseExit()
    // {
    //     
    //     transform.position = startPosition;
    // }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중
        // 마우스 좌표 & 실제 좌표 계산
        mousePosition = eventData.position;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition + new Vector3(0, 0, 9.0f));

        if (_draggable)
        {
            // 드래그 시 오브젝트가 마우스 따라다님
            transform.position = worldPosition;
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Hi");
        
        // 시작 position 저장
        startPosition = transform.position;
        

    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Bye");
        
        if (!_draggable)
        {
            return;
        }

        _draggable = false;
        
        // 드롭 후 일정 y 좌표 이상일시, 카드 종류에 따라 table에 내려놓음
        if (transform.position.y >= 450)
        {
            if (card.cardType == 0)
            {
                transform.SetParent(Table1.transform);
                // transform.localPosition = Vector3.zero;
            }
            else
            {
                transform.SetParent(Table2.transform);
                // transform.localPosition = Vector3.zero;
            }
            // 카드 
            StartCoroutine(MoveToTable());
        }
        else
        {
            // 일정 y 좌표 아래일시 위치 초기화
            transform.position = startPosition;
            _draggable = true;
        }
    }

    IEnumerator MoveToTable()
    {
        // 종료 position 설정
        Vector3 endPossition = transform.parent.transform.position;
    
        // 랜덤 각도 설정
        Quaternion randomAngle = Quaternion.Euler(0, 0, Random.Range(-45.0f, 45.0f));
    
        float elapsedTime = 0.0f;
    
        // 2초 동안 table로 움직임
        while (elapsedTime < 2.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPossition, 150.0f + 20 * elapsedTime );
            // transform.rotation = Quaternion.Lerp(transform.rotation, randomAngle, Time.deltaTime * 2.0f);
        
            elapsedTime += Time.deltaTime;
        
            yield return null;
        }
    
        transform.position = endPossition;
        // 여기서 이벤트를 부를까 -> table의 bool값을 수정?
    }

}
