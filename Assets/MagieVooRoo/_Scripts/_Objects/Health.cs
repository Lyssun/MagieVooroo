using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private int hp = 3;

    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private GameObject deathSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if ( hp == 0)
        {
            if (deathSpawn != null)
            {
                Instantiate(deathSpawn, collision.contacts[0].point, deathSpawn.transform.rotation).SetActive(true);
            }
            Destroy(gameObject);
        }
        
    }
}
