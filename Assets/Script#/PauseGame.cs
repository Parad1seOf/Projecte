using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private enum EGameState 
    {
        READY,
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
        EnterCurrentState();
    }

    void Update()
    {
        if (Input.GetButtonDown(playInput) && (c_gamestate == EGameState.READY || c_gamestate == EGameState.PAUSED))
            ChangeGameState(EGameState.PLAYING);
        else if (Input.GetButtonDown(pauseInput) && c_gamestate == EGameState.PLAYING)
            ChangeGameState(EGameState.PAUSED);
    }

    private void ChangeGameState(EGameState newState)
    {
        if (newState == c_gamestate) return;
        Debug.Log(newState.ToString());
        ExitCurrentState();
        c_gamestate = newState;
        EnterCurrentState();
    }

    private void ExitCurrentState()
    {
        switch (c_gamestate) 
        {
            case EGameState.READY:
                // Ajuste opcional para READY si es necesario
                break;
            case EGameState.PLAYING:
                // No se necesita ningún ajuste específico al salir del estado PLAYING
                break;
            case EGameState.PAUSED:
                Time.timeScale = 1.0f;
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.Play();  // Reanuda la música
                }
                break;
        }
    }

    private void EnterCurrentState()
    {
        switch (c_gamestate)
        {
            case EGameState.READY:
                Time.timeScale = 0.0f;
                break;
            case EGameState.PLAYING:
                Time.timeScale = 1.0f; // Asegúrate de que el tiempo está corriendo cuando el juego está en PLAYING
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.UnPause();  // Reanuda la música si está en pausa
                }
                break;
            case EGameState.PAUSED:
                Time.timeScale = 0.0f;
                if (BackgroundMusic != null)
                {
                    BackgroundMusic.Pause();  // Pausa la música
                }
                break;
        }
    }
}
