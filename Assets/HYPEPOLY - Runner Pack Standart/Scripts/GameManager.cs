using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
//using HexabodyVR.PlayerController;
//using Unity.XR.CoreUtils;
using DarkTonic.MasterAudio;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    //public AudioListener audioListener;
    public static GameManager instance; //singleton instance
    //public Timer timer;

    public int currentLevel = 1; // current level of the player
    public int score = 0; // player's score
    public bool isGameOver = false; // flag to check if the game is over
    public GameObject gameOverScreen; // reference to the game over screen UI
    public GameObject levelUPScreen;

    public GameObject[] coins;

    public GameObject[] WinPanelStars;
    public GameObject[] LosePanelStars;


    public Text timerText;
    public Text CoinCollectionText;
    public Text LiveCountText;
    public int RemainingLives;
    public Text HealthRateText;
    public Image healthImagiFill;
    public GameObject WinLoadMainPanel;
    public Transform[] GameEndLevelPos;
    public int TotalLevelTime;
    public GameObject damageEffect;


   // public SonicPlayer sonicPlayer;

    void Awake()
    {
        
        SetGameSound();
        SetGameTime();
        //timer.StartCountDowntimer(TotalLevelTime);
       // timer.TimeEnded += levelFailedFormTimer;
        Time.timeScale = 1;
        // enforce the singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CoinCollectionText.text = "Coins: 0";
        LiveCountText.text = "live : 3";
        HealthRateText.text = "Health ";

        loadAllCoins();
        SetAllCoinsActive();
       // sonicPlayer.Ondamage += Ondamage;
    }

    public void SetGameTime()
    {
       // timer.StartCountDowntimer(TotalLevelTime);
    }

    private void SetGameSound()
    {
        var volume = PlayerPrefs.GetFloat("volume",1f);
        ////setvalume(volume);
        MasterAudio.MasterVolumeLevel = volume;
    }

    private void setvalume(float value)
    {
        MasterAudio.MasterVolumeLevel = Map01ToNeg90To0(value);
    }
    public float Map01ToNeg90To0(float value)
    {
        return Mathf.Lerp(-90f, 0f , value);
    }
    private void Update()
    {
        //timerText.text = timer.currenttime.ToString();
    }
    private void OnDisable()
    {
       // sonicPlayer.Ondamage -= Ondamage;
    }
    void levelFailedFormTimer()
    {
       // sonicPlayer.lives = 0;
       // sonicPlayer.LevelFailed();
    }
    private void Ondamage()
    {
        damageEffect.SetActive(true);
        StartCoroutine(SetUnactiveDamageEffect());
    }
    IEnumerator SetUnactiveDamageEffect()
    {
        yield return new WaitForSeconds(100);
    }
    public void ClearAllCoins()
    {
        for(int i = 0; i < coins.Length; i++)
        {
            coins[i] = null;
        }
    }
    public void SetAllCoinsActive()
    {
        foreach(GameObject obj in coins)
        {
            obj.gameObject.SetActive(true);
        }
    }

    private void loadAllCoins()
    {
        coins =  GameObject.FindGameObjectsWithTag("ring");
    }

    public void GotoNextLevel()
    {
      //  sonicPlayer.IsLevelComplete = false;
        StartCoroutine(gotoNExtlevel());
    }
    IEnumerator gotoNExtlevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if (asyncLoad.isDone)
        {
           // sonicPlayer.gameplaycanvas.SetActive(true);
            loadAllCoins();
        }
    }
   
    private void SetUnlockedLevel(int level)
    {
        PlayerPrefs.SetInt("UnlockedMaxLevel", level);
    }

    public void OnLevelComplete()
    {
        Debug.Log("Level Completed sucessfully");
        //SetPanelPos(currentLevel);
         currentLevel++;
       // PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        SetUnlockedLevel(currentLevel);
        //SetStars(RemainingLives);
        levelUPScreen.SetActive(true);
        //playerOFFController.SetActive(false);
       // RayCastUI.SetActive(true);
        


    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void Restart()
    {
        // restart the game
       /* sonicPlayer.ResetBodyToStartPos();
        sonicPlayer.gameplaycanvas.SetActive(true);
        sonicPlayer.LevelCompleteCanvas.SetActive(false);*/
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 2);
        score = 0;
    }

    public void SaveProgress()
    {
        // Save the player's progress to a file or the player prefs
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadProgress()
    {
        // Load the player's progress from a file or the player prefs
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public void GameOver()
    {
        isGameOver = true;
        SetStars(RemainingLives);
   //  sonicPlayer.bondyinputs.CanMove = false;
        gameOverScreen.SetActive(true);
        //RayCastUI.SetActive(true);
        //playerOFFController.SetActive(false);
        
        //Time.timeScale = 0;
    }

    public void RestartGame()
    {
           SetGameTime();
       
       // sonicPlayer.PauseOpen = false;
       // sonicPlayer.PauseScreen.SetActive(false);
             isGameOver = false;
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
       /* sonicPlayer.IsLevelComplete = false;
       sonicPlayer.lives = 3;
        sonicPlayer.bondyinputs.CanMove = true;
        sonicPlayer.currentHealth = 100;
        healthImagiFill.fillAmount = 1;
        sonicPlayer.ringsCollected = 0;
        sonicPlayer.ResetBodyToStartPos();
        sonicPlayer.gameplaycanvas.SetActive(true);
        sonicPlayer.LevelCompleteCanvas.SetActive(false);*/
        //currentLevel = PlayerPrefs.GetInt("CurrentLevel", 2) - 1;
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       instance.CoinCollectionText.text = "Coins: " + 0.ToString();
       LiveCountText.text = "Coins: " + 3.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

    public void SetPanelPos(int currentLevel)
    {
        //var transfor = GameEndLevelPos[currentLevel-1];
        //WinLoadMainPanel.transform.position = transfor.position;
    }

   
    public void SetStars(int remainingLives)
    {
        for(int i = 0; i < remainingLives; i++)
        {
            if(WinPanelStars[i].gameObject != null)
            WinPanelStars[i].SetActive(true);

            if (LosePanelStars[i].gameObject != null)
                LosePanelStars[i].SetActive(true);
        }
    }
    public void ResumeGame()
    {
        /*sonicPlayer.gameplaycanvas.SetActive(true);
        sonicPlayer.PauseOpen = false;
        sonicPlayer.bondyinputs.CanMove = true;
        sonicPlayer.PauseScreen.SetActive(false);*/

    }
    public void ReturnToHome()
    {
       // sonicPlayer.PauseOpen = false;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
        foreach (var obj in objs)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("MainMenu");
    }
    public void MoveToNextLevel()
    {
       ClearAllCoins();
       GotoNextLevel();
        levelUPScreen.SetActive(false);
        //sonicPlayer.bondyinputs.CanMove = true;
        //GameManager.instance.playerOFFController.SetActive(true);
        //GameManager.instance.RayCastUI.SetActive(false);
      // sonicPlayer.ResetBodyToStartPos();
    }
}
