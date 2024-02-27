using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // public Text redCounterText;
    // public Text greenCounterText;
    // public Text blueCounterText;
    public int currentLevel;
    public int maxLevel;

    // private int redCount;
    // private int greenCount;
    // private int blueCount;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // redCount = 1;
        // greenCount = 1;
        // blueCount = 1;

        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.Save();

        Time.timeScale = 1f;

        // UpdateCounters();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<PauseGame>().TogglePause();
        }
    }

    // public bool IsColorAvailable(Color color)
    // {
    //     if (color == Color.red)
    //         return redCount > 0;
    //     else if (color == Color.green)
    //         return greenCount > 0;
    //     else if (color == Color.blue)
    //         return blueCount > 0;
    //     return false;
    // }

    // public void UpdateCounter(Color color)
    // {
    //     if (color == Color.red)
    //         redCount++;
    //     else if (color == Color.green)
    //         greenCount++;
    //     else if (color == Color.blue)
    //         blueCount++;
    //     UpdateCounters();
    // }

    // public void UpdateCounter(string color, int incrementValue)
    // {
    //     switch (color)
    //     {
    //         case "Red":
    //             redCount += incrementValue;
    //             break;
    //         case "Green":
    //             greenCount += incrementValue;
    //             break;
    //         case "Blue":
    //             blueCount += incrementValue;
    //             break;
    //     }
    //     UpdateCounters();
    // }

    // void UpdateCounters()
    // {
    //     redCounterText.text = "" + redCount;
    //     greenCounterText.text = "" + greenCount;
    //     blueCounterText.text = "" + blueCount;
    // }

    public void DestroyGameInstance()
    {
        // Application.Quit();
        FindObjectOfType<EndGame>().End(false);
    }

    //Call this method when player reaches the end of the level
    public void LevelClear()
    {
        // Application.Quit();
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        Debug.Log("Current level: " + currentLevel);
        if (currentLevel == maxLevel)
        {
            Debug.Log("Reached maxlevel");
            return;
        }
        PlayerPrefs.SetInt("maxLevel", currentLevel + 1);
        PlayerPrefs.Save();
        FindObjectOfType<EndGame>().End(true);
    }
}
