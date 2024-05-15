using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    private enum GMStates 
    {
        READY,
        PLAYING,
        PAUSED
    }

    private GMStates GMState = GMStates.READY;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GMState == GMStates.PLAYING)
            {
                GMState = GMStates.PAUSED;
                Time.timeScale = 0;
            }
            else if (GMState == GMStates.PAUSED)
            {
                GMState = GMStates.PLAYING;
                Time.timeScale = 1;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}