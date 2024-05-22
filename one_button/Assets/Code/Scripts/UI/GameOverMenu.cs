using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenuUI;
    [SerializeField]
    string LoadScene; //scene name

    //set game time back to normal and load restartScene
    public void RestartGame()
    {
        SceneManager.LoadScene(LoadScene);
    }
    public void HandleGameOver()
    {
        //pause time/game
        Time.timeScale = 0f;

        //enables the cursor and turns it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverMenuUI.SetActive(true);
    }
}
