using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmove : MonoBehaviour
{
    public GameObject goA;
    public GameObject goB;
    public GameObject goC;
    UFOshoot shoot;
    GameObject goTarget;

    public float speed;

    void Start()
    {
        transform.position = goA.transform.position; // TELETRANSPORTAR A POSICION INICIAL
        goTarget = goB;
        shoot = GetComponent<UFOshoot>();
        MoveToTarget(speed);
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, goTarget.transform.position);

        if (dist < 0.3f) // HEMOS LLEGADO
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
            MoveToTarget(0);
            StartCoroutine(Move1());
            shoot.Spawner();
        }
    }

    IEnumerator Move1() {
        yield return new WaitForSeconds(0.5f);
        MoveToTarget(speed);
    }

    void MoveToTarget(float vel)
    {
        Vector2 posActual = transform.position;
        Vector2 posFinal = goTarget.transform.position;
        Vector2 dir = (posFinal - posActual).normalized;

        GetComponent<Rigidbody2D>().velocity = vel * dir;
    }
}

