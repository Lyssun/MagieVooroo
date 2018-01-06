using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Script permettant de faire les mouvements du fantome (n'inclus pas la rotation)
* Le fantome avancera vers le joueurs (ou reculera) en fonction de la distance avec le joueur,
* si le joueur est a une certaine distance du fantome, le fantome le poursuivra.
* Quand le fantome est asser proche, il s'arrete. Si le joueur s'approche trop près du fantome,
* Alors il decide de fuir le joueur.
* La vitesse est defini en fonction de la distance, pour la fuite elle prend aussi en compte
*  la difference entre la distance minimum avant la fuite et la distance maximum.
*/
public class GhostMove : MonoBehaviour
{
	/*
	* Represente le joueur, que le fantome poursuivra en fonction de la distance
    */
	GameObject target;

    [SerializeField]
	/*
	* Represente la distance a laquelle le fantome commencera a s'approcher
    */
	float maxDistance = 15f;

    [SerializeField]
	/*
	* Represente la distance a laquelle le fantome fuira
    */
	float minDistance = 5f;
	
	[SerializeField]
	/*
	* Represente la distance a laquelle le fantome arretera d'avancer
	*/
	float medDistance = 10f;
	/* 
	* Represente la distance entre le fantome et le joueur
	*/
	float dist;
	
	// S'execute au démarrage
	/*
	* Essaie de trouver le joueur, si le joueur n'est pas présent dans la scène,
	* Lance une coroutine cherchant le joueur toutes les 0,3 secondes
	* et initialise la variable dist a maxDistance+1
	*/
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            dist = maxDistance + 1;
            StartCoroutine(LookForPlayer());
        }
    }

	// Execute à chaque frame
    private void Update()
    {
        try
        {
            // Calcule de la distance entre 2 vecteurs ==> Sqrt((p1.x - p2.x)² +(p1.y - p2.y)² +(p1.z - p2.z)²)
            dist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) +
						Mathf.Pow(target.transform.position.y - transform.position.y, 2)
						+ Mathf.Pow(target.transform.position.z - transform.position.z, 2));

        }
        catch (NullReferenceException e)
        {
			// le joueur n'a pas encore été trouvé dans la scène.
            Debug.Log(e.Message);
        }
		
        if (dist <= maxDistance)
        {
            if (dist >= medDistance) // s'approche du joueur
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime  * dist);
            else
                if (dist <= minDistance) // fuis le joueur
                		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * (dist-maxDistance+minDistance));
            transform.position = new Vector3(transform.position.x, -0.353f, transform.position.z); // empeche le fantome de varier en Y
        }


    }

	// Cherche le joueur  toutes les 0,3 secondes, quand elle le trouve, elle s'arrete
    IEnumerator LookForPlayer()
    {
		// Tant qu'on ne trouve pas le joueur
        while (target == null)
        {
            yield return new WaitForSeconds(0.3f);
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }


}
