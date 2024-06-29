using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class SkullAnim : MonoBehaviour
{
    public GameObject[] skullSprites;

    public float watingTime = 0.05f;

    private void Start()
    {
        StartCoroutine(MoveSkull());
    }

    IEnumerator MoveSkull()
    {
        float timer = 0.0f;
        foreach (GameObject i in skullSprites)
        {
            gameObject.GetComponent<Image>();
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
    }
}
