using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameStateController : MonoBehaviour
{
    public int numberOfCrystalsInGame;
    public TextMeshProUGUI NumberOfCrystalsLeftUI;
    public TextMeshProUGUI resultUI;
    public GameObject gameStateUI;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfCrystalsInGame <= 0)
        {
            gameOver(true);
        }
        
    }

    public void removeOneCrystal()
    {
        --numberOfCrystalsInGame;
        NumberOfCrystalsLeftUI.text = numberOfCrystalsInGame.ToString();
    }
    public void gameOver(bool result)
    {
        if (result)
        {
            Time.timeScale = 0;
            gameStateUI.SetActive(true);
            resultUI.text = "All Crystals Destoryed";
        }
        else
        {
            Time.timeScale = 0;
            gameStateUI.SetActive(true);
            resultUI.text = "You Died";
        }

    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
