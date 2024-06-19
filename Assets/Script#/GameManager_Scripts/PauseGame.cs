using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Enumerador para los estados del juego
    private enum EGameState 
    {
        PLAYING,
        PAUSED
    }

    public string characterTag = "Player";
    public string playInput = "PlayInput";
    public string pauseInput = "PauseInput";
    
    public AudioSource BackgroundMusic;

    private EGameState c_gamestate = EGameState.PLAYING;

    void Start()
    {
        // Inicializamos el estado del juego
        EnterCurrentState();
    }

    void Update()
    {
        // Si el jugador presiona el boton de pausa, se pausa el juego
        if (Input.GetButtonDown(playInput) && (c_gamestate == EGameState.PAUSED))
            ChangeGameState(EGameState.PLAYING);
        // Si el jugador presiona el boton de pausa, y el juego esta pausado, se reanuda el juego
        else if (Input.GetButtonDown(pauseInput) && c_gamestate == EGameState.PLAYING)
            ChangeGameState(EGameState.PAUSED);
    }

    // Funcion para cambiar el estado del juego
    private void ChangeGameState(EGameState newState)
    {
        if (newState == c_gamestate) return;
        Debug.Log(newState.ToString());
        ExitCurrentState();
        c_gamestate = newState;
        EnterCurrentState();
    }

    // Funcion para salir del estado actual
    private void ExitCurrentState()
    {
        switch (c_gamestate) 
        {
            case EGameState.PLAYING:
                
                break;
            case EGameState.PAUSED:
                Time.timeScale = 1.0f;
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.Play();
                }
                break;
        }
    }

    // Funcion para entrar en el estado actual
    private void EnterCurrentState()
    {
        switch (c_gamestate)
        {
            case EGameState.PLAYING:
                Time.timeScale = 1.0f;
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.UnPause();
                }
                break;
            case EGameState.PAUSED:
                Time.timeScale = 0.0f;
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.Pause();
                }
                break;
        }
    }
}
