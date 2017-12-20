using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    /**
     * Load the first level Scene
     */
    public void Jouer()
    {
        SceneManager.LoadScene(1);
    }

    /**
    * Load the Random Scene
    */
    public void Aleatoire()
    {
        SceneManager.LoadScene(5);
    }

    /**
     * Quit the application.
     */
    public void Quitter()
    {
        Application.Quit();
    }
}