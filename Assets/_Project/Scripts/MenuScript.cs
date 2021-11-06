using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("HistoireScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
