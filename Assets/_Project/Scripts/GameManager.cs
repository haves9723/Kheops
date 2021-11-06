using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private string startScene;
    public TextMeshProUGUI coinText;
    [SerializeField] private int coins;

    public GameOverScreen GameOverScreen;
    //Singleton
    public static GameManager instance;
    

    void Awake()
    {

        if (instance == null)
        {
            coinText.text = coins.ToString() + " €";
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

    public void setCoins(int newValue)
    {
        coins = newValue;
        coinText.text = coins + " €";
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
        Enemy.enemies.RemoveAll(enemy => true );
        SceneManager.LoadScene("MainScene");
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