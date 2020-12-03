using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverUI, pauseUI, gamewinUI, startUI;
    

    void Start()
    {
        PlayerPrefs.SetInt("CURRENTSCENE",SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        
    }
    void Update()
    {
        
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
            
    }
    
    
    
    public void PauseGame()
    {
       
        pauseUI.SetActive(true);
        Time.timeScale = 0f;

    }
    
    public void ResumeGame()
    {
       
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void WinGame()
    {
       
        gamewinUI.SetActive(true);
        
    }
    
    public void NextLevel()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
    }
    
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        
    }
    public void QuitGame()
    {
        Application.Quit();
     
    }
}
