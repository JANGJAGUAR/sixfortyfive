using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{
    private int _ballNumber;
    
    [SerializeField]
    private TMP_Text ballText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddBall(int ballNumber, int leftCount)
    {
        _ballNumber = ballNumber;
        StartCoroutine(NumberRolling(leftCount));
    }

    IEnumerator NumberRolling(int leftCount)
    {
        for(int i=0; i<leftCount; i++)
        {
            yield return new WaitForSeconds(0.2f);
        }

        if (_ballNumber == 0)
        {
            for(int i=1; i<45; i++)
            {
                ballText.text = ((_ballNumber + i)).ToString();
                yield return new WaitForSeconds(0.04f);
            }
            ballText.text = 0.ToString();
        }
        else
        {
            for(int i=1; i<=45; i++)
            {
                if (i + _ballNumber > 45)
                {
                    ballText.text = ((_ballNumber + i) - 45).ToString();
                }
                else
                {
                    ballText.text = (_ballNumber + i).ToString();
                }
            
                yield return new WaitForSeconds(0.04f);
            }
        }
        
        
    }
    

}
