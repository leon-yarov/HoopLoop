using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_script : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    public void PauseToggle()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
