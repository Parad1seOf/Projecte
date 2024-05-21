using UnityEngine;
using UnityEngine.SceneManagement;
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

    private EGameState c_gamestate = EGameState.READY;

    void Start()
    {
        EnterCurrentState();
    }

    void Update()
    {
        if (Input.GetButtonDown(playInput) && (c_gamestate == EGameState.READY || c_gamestate == EGameState.PAUSED))
            ChangeGameState(EGameState.PLAYING);

        else if(Input.GetButtonDown(pauseInput) && c_gamestate == EGameState.PLAYING)
            ChangeGameState(EGameState.PAUSED);
    }

    private void ChangeGameState(EGameState newState)
    {
        if (newState == c_gamestate)
            return;
        Debug.Log(newState.ToString());
        ExitCurrentState();
        c_gamestate = newState;
        EnterCurrentState();
    }

    private void ExitCurrentState()
    {
        switch(c_gamestate) 
        {
            case EGameState.READY:
                Time.timeScale = 1.0f;
                break;
            case EGameState.PLAYING:
                break;
            case EGameState.PAUSED:
                Time.timeScale = 1.0f;
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
                break;
            case EGameState.PAUSED:
                Time.timeScale = 0.0f;
                break;
        }
    }
}