using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject loserPanel;
    [SerializeField] private GameObject winnerPanel;
    
    [SerializeField] private GameObject[] livesImg;

    [SerializeField] private Text gameTimeText;

    [SerializeField] private AudioClip buttonPress;

    public void ActivateLoserPanel(){
        loserPanel.SetActive(true);
    }

    public void ActivateWinnerPanel(){
        winnerPanel.SetActive(true);
    }

    public void RestartCurrentScene(){
        
        /*
        Asi se hacia de normal pero he creado la otra linea para que lo mande a la escena activa, por si hay mas de una
        aunque no se si estará correcto, probar y si no usar esta linea u otra forma: 
        SceneManager.LoadScene("BreakoutScene1");
        */
        
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        SceneManager.LoadScene("BreakoutMenu");
    }

    public void UpdateUILives(byte currentLives)
    {
        for (int i = 0; i < livesImg.Length; i++)
        {
            if (i>=currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }

    public void ActivateWinnerPanel(float gameTime)
    {
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + "s";
        //Con Mathf.Floor(gameTime) nos deshacemos de todos los decimales
    }

}
