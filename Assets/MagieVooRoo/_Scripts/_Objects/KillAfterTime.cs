using UnityEngine;

/**
 * Classe permettant de detruire un objet apres un laps de temps
 */
public class KillAfterTime : MonoBehaviour {

    /**
     *Represente la duree de vie
     */
    [SerializeField]
    [Tooltip("Time to live of the GameObject.")]
    private float TTL = 12f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, TTL);
	}
	
}
