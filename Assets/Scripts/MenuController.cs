using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelsPanel;
    public void PlayPressed()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
