using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenuUI;
    [SerializeField]
    string LoadScene;
    [SerializeField]
    bool IsGamePaused = false;

    //set game time back to normal and load restartScene
    public void Load()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LoadScene);
    }
    //public void HandleGameOver()
    //{
    //    if (!IsGamePaused)
    //        Load();
    //}

}
