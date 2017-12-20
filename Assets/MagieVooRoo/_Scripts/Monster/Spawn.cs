using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    private Text text;
    private int nb_target;
    private bool genFinished = false;

    void Start () {
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
        Instantiate(player, transform.position + Vector3.up, transform.rotation);
        StartCoroutine(ChangeNbTarget());

    }

    IEnumerator ChangeNbTarget()
    {
        nb_target = 0;
        int i = 1;
        while (!genFinished)
        {
            nb_target = GameObject.FindGameObjectsWithTag("Target").Length;
            text.text = "Target left : " + nb_target;
            yield return new WaitForSeconds(i);
            genFinished = true;
            i++;
        }

        GameObject.FindGameObjectWithTag("Exit").GetComponent<Portal>().AddNbTarget(nb_target);

    }

    public bool GetGenFinished()
    {
        return genFinished;
    }

    public bool SetGenFinished()
    {
        return genFinished;
    }
}
