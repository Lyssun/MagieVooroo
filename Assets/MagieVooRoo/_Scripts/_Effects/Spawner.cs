using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Un Generateur d'objet
 * Creer un objet quand la touche est pressee
 */
public class Spawner : MonoBehaviour {
    // l'objet qui va etre cree
    public GameObject obj;
    // la touche utiliser pour faire apparaitre l'objet
    public string key = "Jump";
   
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(key))
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }
}
