using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable_Item : MonoBehaviour {
    [SerializeField]
    private GameObject destroyed;
    private int hp = 1;



    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if ( hp == 0)
        {
            destroyed.SetActive(true);
        }
    }
}
