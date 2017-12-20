using UnityEngine;

public class Breakable_Item : MonoBehaviour {
    [SerializeField]
    [Tooltip("The object that would replace the item after you destroyed this one.")]
    private GameObject destroyed;
    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private int hp = 3;

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if ( hp == 0)
        {
            Instantiate(destroyed,transform.position,transform.rotation).SetActive(true);
            Destroy(gameObject);
        }
    }
}
