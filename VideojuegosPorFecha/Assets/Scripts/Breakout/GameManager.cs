using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private float gameTime;
    
    private byte bricksOnLevel;
    //Propiedades --> Pagina 189 - Unity 2022:Aprende a desarrolla videojuegos
    public byte BricksOnLevel
    {
        get => bricksOnLevel;
        set
        {
            bricksOnLevel=value;
            if (bricksOnLevel==0)
            {
                Debug.Log("Has ganado el nivel");
                Destroy(GameObject.Find("Ball"));
                
                //Mostrar pantalla de victoria y el tiempo total
                gameTime = Time.time * gameTime;
                FindObjectOfType<UIController>().ActivateWinnerPanel(gameTime);
                
                //Medir el tiempo del juego
                gameTime = Time.time - gameTime;
            }
        } 
    }

    [SerializeField] private byte playerLives = 3;
    public byte PlayerLives
    {
        get => playerLives;
        set
        {
            playerLives = value;
            if (playerLives == 0)
            {
                Debug.Log("Has perdido el juego");
                Destroy(GameObject.Find("Ball"));
                
                //Mostrar pantalla de derrota
                FindObjectOfType<UIController>().ActivateLoserPanel();
            }
            else
            {
                FindObjectOfType<Ball>().ResetBall();
            }
            FindObjectOfType<UIController>().UpdateUILives(playerLives);
        }
    }

    [SerializeField] private bool gameStarted;
    public bool GameStarted
    {
        get => gameStarted;
        set
        {
            gameStarted = value;
            gameTime = Time.time;
        }
    }

    [SerializeField] private bool ballOnPlay;
    public bool BallOnPlay
    {
        get => ballOnPlay;
        set
        { 
            ballOnPlay = value;
            if (ballOnPlay)
            {
                Debug.Log("Lanzar la bola");
                FindObjectOfType<Ball>().LaunchBall();
            }
        } 
    }




}
