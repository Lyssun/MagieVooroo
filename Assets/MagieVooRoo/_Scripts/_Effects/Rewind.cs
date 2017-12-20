using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The number of seconds that we record.")]
    private float recordTime = 5f;

    [SerializeField]
    [Tooltip("Freeze the item at the end of the rewind time.")]
    private bool freezeAfterRewind = true;
    private bool isRewinding = false;
    private List<RewindPoint> tabRewindTime;
    private Renderer ren;
    private Color oldColor;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ren = GetComponent<Renderer>();
        oldColor = ren.material.color;
        tabRewindTime = new List<RewindPoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
    }

    void FixedUpdate()
    {
        if (isRewinding)
            RewindTime();
        else
            Record();
    }

    void RewindTime()
    {
        if (tabRewindTime.Count > 0)
        {

            RewindPoint rewindTime = tabRewindTime[0];
            transform.position = rewindTime.position;
            transform.rotation = rewindTime.rotation;
            tabRewindTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        if (tabRewindTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            tabRewindTime.RemoveAt(tabRewindTime.Count - 1);
        }
        tabRewindTime.Insert(0, new RewindPoint(transform.position, transform.rotation));
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        ren.material.color = new Color(1f, 0.50f, 0.25f);
        
        //ren.material.color = new Color((float)((int)(Random.Range(0, 255))) / 255, (float)((int)(Random.Range(0, 255))) / 255, (float)((int)(Random.Range(0, 255))) / 255);


    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
        if (freezeAfterRewind)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        ren.material.color = oldColor;
        //rb.useGravity = false;
    }
}