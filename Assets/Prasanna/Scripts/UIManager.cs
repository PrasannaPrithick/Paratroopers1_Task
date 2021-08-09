using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    public GameObject mainMenu_GO;
    public Button play_Button;
    public Button difficultyLevel;
    public GameObject difficultyLevel_Popup_GO;
    public Button exitButton;
    public Slider difficultyLevelSlider;
    public TextMeshProUGUI difficultyLevelText;
    public Button difficultyLevelPopupClose_Button;

    public TextMeshProUGUI gamePlayScore_Text;
    public GameObject inGameUI_GO;

    public Button gameBack_Button;


    public GameObject gameOver_GO;
    public TextMeshProUGUI gameOver_YourScore_Text;
    public Button rematch_Button;

    public void GameOverPopup() 
    {
        gameOver_GO.SetActive(true);
        gameOver_YourScore_Text.text = GameManager.instance.gameScore+"";

    }

    

    
    // Start is called before the first frame update
    void Start()
    {
        mainMenu_GO.SetActive(true);
        inGameUI_GO.SetActive(false);
        ButtonListener();
        Time.timeScale = 0.0f;
        
    }

    public void ScoreUpdate(int score) 
    {
        GameManager.instance.gameScore += score;
        gamePlayScore_Text.text = GameManager.instance.gameScore + "";
    }

    private void PlayButtonAction() 
    {
        mainMenu_GO.SetActive(false);
        inGameUI_GO.SetActive(true);
        Time.timeScale = 1.0f;
        GameManager.instance.gameStarted = true;
    }
    private void DifficultyLevelAction() 
    {
        difficultyLevel_Popup_GO.SetActive(true);
        DifficultLevelOnChange();
    }
    private void DifficultyLevelCloseButtonAction() 
    {
        difficultyLevel_Popup_GO.SetActive(false);
    }
    private void ExitButtonAction() 
    {
        Application.Quit();
    }

    //Reference in Inspector...
    public void DifficultLevelOnChange() 
    {
        difficultyLevelText.text = difficultyLevelSlider.value.ToString();
        DifficultyLevel();
        //GameManager.instance.gameLevel = (int)difficultyLevelSlider.value;
    }
    private void DifficultyLevel() 
    {
        int difficultLevel = (int)difficultyLevelSlider.value;
        if (difficultLevel == 1) 
        {
            GameManager.instance.gameLevel = 3.0f;
        }
        else if(difficultLevel == 2)
        {
            GameManager.instance.gameLevel = 2.8f;
        }
        else if (difficultLevel == 3)
        {
            GameManager.instance.gameLevel = 2.5f;
        }
        else if (difficultLevel == 4)
        {
            GameManager.instance.gameLevel = 2.3f;
        }
        else if (difficultLevel == 5)
        {
            GameManager.instance.gameLevel = 2.0f;
        }
        else if (difficultLevel == 6)
        {
            GameManager.instance.gameLevel = 1.8f;
        }
        else if (difficultLevel == 7)
        {
            GameManager.instance.gameLevel = 1.5f;
        }
        else if (difficultLevel == 8)
        {
            GameManager.instance.gameLevel = 1.3f;
        }
        else if (difficultLevel == 9)
        {
            GameManager.instance.gameLevel = 1.0f;
        }
        else if (difficultLevel == 10)
        {
            GameManager.instance.gameLevel = 0.5f;
        }
    }
    public static UIManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    private void ButtonListener() 
    {
        play_Button.onClick.AddListener(PlayButtonAction);
        difficultyLevel.onClick.AddListener(DifficultyLevelAction);
        difficultyLevelPopupClose_Button.onClick.AddListener(DifficultyLevelCloseButtonAction);
        exitButton.onClick.AddListener(ExitButtonAction);
        gameBack_Button.onClick.AddListener(BackButtonFunctionality);
        rematch_Button.onClick.AddListener(BackButtonFunctionality);

    }
    private void BackButtonFunctionality() 
    {
        SceneManager.LoadScene(0);
    }

}
