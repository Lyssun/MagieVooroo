using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private int hp = 4;

    [SerializeField]
    private GameObject particle;

    [SerializeField]
    private GameObject father;

    private void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if (hp == 0)
        {
            StartCoroutine(Death());
            GetComponent<MeshCollider>().enabled = false;
        }
    }

    IEnumerator Death()
    {
        
        while (father.transform.localScale.z >= 0.05f)
        {
            yield return new WaitForSeconds(0.01f);
            father.transform.localScale *= 0.9f;
        }
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(father);
    }

 
}