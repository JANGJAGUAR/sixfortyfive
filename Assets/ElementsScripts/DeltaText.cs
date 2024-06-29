using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DeltaText : MonoBehaviour
{
    public TMP_Text text;
    
    private void Start()
    {
        text = GetComponent<TMP_Text>();

        StartCoroutine(StartDeltaText());
    }

    IEnumerator StartDeltaText()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime <= 1.0f)
        {
            transform.position += Vector3.up * 2.0f;
            text.alpha = (1 - elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
