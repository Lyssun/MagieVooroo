using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    [SerializeField]
    float maxDistance = 15f;

    [SerializeField]
    float minDistance = 5f;

    float dist;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            dist = maxDistance + 1;
            StartCoroutine(LookForPlayer());
        }
    }


    private void Update()
    {

        try
        {
            // Calcule de la distance entre 2 vecteurs ==> racine((p1.x - p2.x)² +(p1.y - p2.y)² +(p1.z - p2.z)²)
            dist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.y - transform.position.y, 2) + Mathf.Pow(target.transform.position.z - transform.position.z, 2));

        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }

        if (dist <= maxDistance)
        {
            if (dist >= minDistance + 5)
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime  * dist);
            else
                if (dist <= minDistance)
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * (dist-maxDistance+minDistance));
            transform.position = new Vector3(transform.position.x, -0.353f, transform.position.z);
        }


    }


    IEnumerator LookForPlayer()
    {
        while (target == null)
        {
            yield return new WaitForSeconds(0.1f);
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }


}
