using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The health point of the object, lose on hp at every collision.")]
    private int hp = 4;

    [SerializeField]
    private GameObject particle;

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        if (hp == 0)
        {
            StartCoroutine(Death());
            GameObject.FindGameObjectWithTag("Exit").GetComponent<Portal>().DecreaseNbTarget();
        }
    }

    IEnumerator Death()
    {
        GetComponent<BoxCollider>().enabled = false;
        while (transform.localScale.z >= 0.05f)
        {
            yield return new WaitForSeconds(0.01f);
            
            transform.localScale *= 0.9f;
        }
        Instantiate(particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


