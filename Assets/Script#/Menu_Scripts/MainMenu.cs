using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Cargar la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    // Salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }
    // Cargar la escena de opciones
    public void Options()
    {
        SceneManager.LoadSceneAsync(2);
    }
    // Vuelve al menu principal desde las opciones
    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
