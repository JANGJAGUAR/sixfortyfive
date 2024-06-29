using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableArrange : MonoBehaviour
{
    public float spacing = 1.0f;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y, transform.childCount - (i * spacing));
        }
    }
}
