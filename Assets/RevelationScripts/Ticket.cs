using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 endPos;
    [SerializeField] private float moveSpeed;

    public void ShootTicket()
    {
        StartCoroutine(ShootTicketCoroutine());
    }

    IEnumerator ShootTicketCoroutine()
    {
        while (true)
        {
            gameObject.transform.Translate(Vector3.left*(moveSpeed*Time.deltaTime));
            if (gameObject.transform.position.x < endPos.x) break;
            yield return null;
        }

        gameObject.transform.position = startPos;
    }
    
}
