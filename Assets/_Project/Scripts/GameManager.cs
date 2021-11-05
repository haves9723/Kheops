using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string startScene;
    public TextMeshProUGUI coinText;
    [SerializeField] private int coins;

    public GameOverScreen GameOverScreen;
    //Singleton
    public static GameManager instance;
    

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

    public void update()
    {

    }

    public void setCoins(int value)
    {
        coins += value;
        coinText.text = coins.ToString() + " €";
    }

    public int getCoins()
    {
        return coins;
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