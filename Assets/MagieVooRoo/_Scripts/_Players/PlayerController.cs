using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 a = transform.forward * speed * moveVertical;
        a.y = rb.velocity.y;
        if (rb.velocity.y >= 1)
            a.y *= 0.9f;
        rb.velocity = a;
        transform.Rotate(new Vector3(0f, moveHorizontal*2 ,0f));
    }
}