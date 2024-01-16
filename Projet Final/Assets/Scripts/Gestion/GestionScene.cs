using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{

    // But: Changer la scène
    public void ChargerScene()
    {
        int sceneCourante = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneCourante + 1);
    }

    // But: Quitter le jeu
    public void Quitter()
    {
        Application.Quit();
    }
}
