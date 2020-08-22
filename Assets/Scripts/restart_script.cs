using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_script : MonoBehaviour
{
    public void Restart() //restart current scene
    {
        Time.timeScale = 1; //reset time scale, (restarting the scene while the game is paused will keep the timeScale value of 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(Scene scene) //start with passed scene name
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene.name);
    }
    public void PauseToggle() //Toggle pause
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
