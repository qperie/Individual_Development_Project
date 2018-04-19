using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("Jeu", LoadSceneMode.Single);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
