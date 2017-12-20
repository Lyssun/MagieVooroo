using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostLookAt : MonoBehaviour {
    GameObject target;
    private Vector3 initialRotation;

    void Start()
    {
        // Get initial rotation
        initialRotation = new Vector3(0f, 90f, 0f);
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            StartCoroutine(LookForPlayer());
        }
    }

    void Update()
    {
        try
        {
            transform.LookAt(target.transform);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }

        transform.eulerAngles = new Vector3(0, initialRotation.y + transform.eulerAngles.y, 0);

    }

    IEnumerator LookForPlayer()
    {
        while (target == null)
        {
            yield return new WaitForSeconds(0.01f);
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
