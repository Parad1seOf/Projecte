using UnityEngine;

public class PauseGame : MonoBehaviour
{
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
        EnterCurrentState();
    }

    void Update()
    {
        if (Input.GetButtonDown(playInput) && (c_gamestate == EGameState.PAUSED))
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
