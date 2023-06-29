using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int numeroRandom;
    
    private GameObject gameManagerObj;
    private GameManager _gameManager;

    [SerializeField] private GameObject explosionPrefab;
    
    void Start()
    {
        gameManagerObj = GameObject.Find("GameManager");
        if (gameManagerObj == null)
        {
            Debug.Log("Object not found");
        }
        else
        {
            _gameManager = gameManagerObj.GetComponent<GameManager>();
            _gameManager.BricksOnLevel++; //Esto aumentará en 1 por cada bloque que hay en la escena ya que cada uno tiene la clase Brick haciendo uso de la propiedad
        }

        /*
         NO USADO FINALMENTE, PUESTO EN LINEA CON IMAGENES PREDEFINIDAS
        
        //Añadir colores random a los bloques
        numeroRandom = Random.Range(0,6);

        if (numeroRandom == 1)
        {
            _spriteRenderer.color = Color.yellow;
        } 
        else if (numeroRandom == 2)
        {
            _spriteRenderer.color = Color.red;
        }
        else if (numeroRandom == 3)
        {
            _spriteRenderer.color = Color.green;
        }
        else if (numeroRandom == 4)
        {
            _spriteRenderer.color = Color.cyan;
        }
        else
        {
            _spriteRenderer.color = Color.magenta;
        }
        
        */
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        if (_gameManager != null)
        {
            _gameManager.BricksOnLevel--; 
        }

        Destroy(gameObject);
    }
}
