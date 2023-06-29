using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // métodos para cambiar de escena con botón, sobrecargados para string e int
    public void ChangeScene(string scene)
    {
        //metodo para cambiar por string. (en este caso para cambiar con el nombre del juego al menú de este)
        
        SceneManager.LoadScene(scene);
    }
    
    public void ChangeScene(int scene)
    {
        //metodo para cambiar por int (numero de escena)
        
        SceneManager.LoadScene(scene);
        
    }

    // método para el botón de salir
    public void Exit()
    {
        Application.Quit();
    }
}
