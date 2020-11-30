using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmove : MonoBehaviour
{
    public GameObject goA;
    public GameObject goB;
    public GameObject goC;

    GameObject goTarget;

    public float speed;

    void Start()
    {
        transform.position = goA.transform.position; // TELETRANSPORTAR A POSICION INICIAL
        goTarget = goB;

        MoveToTarget();
    }

    void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position, goTarget.transform.position);

        if (dist < 0.2f) // HEMOS LLEGADO
        {
            if (goTarget == goA)
            {
                goTarget = goB;
            }
            else if (goTarget == goB)
            {
                goTarget = goC;
            }
            else if (goTarget == goC)
            {
                goTarget = goA;
            }
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector2 posActual = transform.position;
        Vector2 posFinal = goTarget.transform.position;
        Vector2 dir = (posFinal - posActual).normalized;

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}

