using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    [SerializeField] private string startScene;
    private GameManager instance;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void startGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}