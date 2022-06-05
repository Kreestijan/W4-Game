using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlaySinglePlayer()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("MultiplayerMenu");
    }
}
