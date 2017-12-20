using UnityEngine;


/**
 * Attire tous les objets ayant le tag Object
 */
public class Vortex : MonoBehaviour {
    /**
     * Gravity constant
     */
    [SerializeField]
    [Tooltip("The gravity strength of the black hole")]
    private float GC = 6.67408f;


    // minimum distance to be attracted 
    [SerializeField]
    [Tooltip("The minimum distance to be attracted")]
    private float attractDist = 0.05f;

    // minimum distance  to be slowed and stopped
    [SerializeField]
    [Tooltip("The minimum distance  to be slowed and stopped")]
    private float stopDist = 0.01f;

    // To know if the velocity would be decreased when the object is far from the position.
    [SerializeField]
    [Tooltip("If the velocity would be decreased when the object is far from the position")]
    private bool decrease = true;

    /**
     * Attire tous les objets ayant le tag Object proche par rapport a la distance et la masse
     * sauf si la distance est inferier a 5.
     */
    void Update () {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object"))
        {
            Vector3 offset = transform.position - go.transform.position;
            //calcule de la distance
            float dist = offset.sqrMagnitude;

            if (dist > attractDist)
            {
                // if activated , decrease the object's velocity to get a controlled motion
                if (decrease)
                    go.GetComponent<Rigidbody>().velocity *= 0.9f;
                /*
                 * Represent the attract force.
                 * We add a force by combining the direction,
                 * the mass of the object, the gravityConstant, the distance and the strength.
                 */
                go.GetComponent<Rigidbody>().velocity = go.GetComponent<Rigidbody>().velocity + 3 * (GC * offset.normalized * go.GetComponent<Rigidbody>().mass) / (dist * dist);
            }
            //if the object is near
            else if (dist >= stopDist)
                // Decrease and negate velocity of the object to prevent
                // it from passing trought the pos.
                go.GetComponent<Rigidbody>().velocity *= -0.9f;
            }


        
    }
}