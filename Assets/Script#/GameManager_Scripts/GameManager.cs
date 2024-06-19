using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    private int lives = 5;

    // Si no hay una instancia de GameManager, se crea una y se mantiene en todas las escenas
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Funcion para restar vidas al jugador
    public void LoseHP()
    {
        lives -= 1;
        if (hud != null)
        {
            hud.UnableLives(lives);
        }
    }
}
