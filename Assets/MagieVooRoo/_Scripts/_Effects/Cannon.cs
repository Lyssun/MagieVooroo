using UnityEngine;

/**
 * Un Generateur d'objet appliquant une force pour le propulser.
 * Creer un objet quand la touche est pressee
 */ 
public class Cannon : MonoBehaviour {
    [SerializeField]
    GameObject obj;
    [SerializeField]
    float force = 300f;
    [SerializeField]
    string key = "Jump";
    

	// Update is called once per frame
	void Update () {
       if (Input.GetButtonDown(key))
        {
            Instantiate(obj, transform.position, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * force);
        }

    }
}
