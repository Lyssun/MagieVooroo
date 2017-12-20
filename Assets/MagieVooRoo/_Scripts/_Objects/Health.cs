using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private int hp = 3;



    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if ( hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
