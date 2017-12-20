using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour {

    [SerializeField]
    private List<GameObject> listParticle;
    [SerializeField]
    private int nb_target = 0;
    [SerializeField]
    private Text text;

    private void Start()
    {
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.tag == "Player" && nb_target == 0)
        {
            // fin de niveau
            GameObject.FindGameObjectWithTag("Text").GetComponent<Text>().text = "You win :) ! ";
        }
    }

    public void AddNbTarget(int nb)
    {
        nb_target += nb;
    }

    public void DecreaseNbTarget()
    {
        if(--nb_target == 0)
            foreach (GameObject go in listParticle)
                go.SetActive(true);
        text.text = "Target left : " + nb_target;
    }

}
