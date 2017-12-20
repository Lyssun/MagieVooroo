using UnityEngine;

public class LaunchFireball : MonoBehaviour {
    [SerializeField]
    [Tooltip("Add your object that you want to initiate, should be the fireball prefab.")]
    private GameObject obj;

    // Create and propulse a fireball
    void Launch(float force, Vector3 position, Vector3 rotation)
    {
        Quaternion rotationQuat = new Quaternion
        {
            eulerAngles = rotation
        };
        GameObject fb = Instantiate(obj, position, rotationQuat);
        fb.transform.position += fb.transform.forward * -2; 
        fb.GetComponent<Rigidbody>().AddForce(-1 * fb.transform.forward * force);
    }

}
