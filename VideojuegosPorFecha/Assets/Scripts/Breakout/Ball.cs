using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Para el movimiento de la bola utilizaremos el motor de fisicas (Rigidbody2D)
    private Rigidbody2D rigidbody2d;

    private Vector2 moveDirection;
    [SerializeField] private Vector2 currentVelocity;
    [SerializeField] private float ballSpeed = 5;

    private GameManager _gameManager;

    [SerializeField] private AudioClip paddleBounce;
    [SerializeField] private AudioClip bounce;
    [SerializeField] private AudioClip loseLife;
    
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos una referencia al componente Rigidbody2D almacenado dentro del mismo objeto que contiene este script
        rigidbody2d = GetComponent<Rigidbody2D>();
        /*Otra forma de obtener referencias es desde la ventana de inspector, haciendo la variable publica y añadiendo el
          componente a esta
        */
       
        // rigidbody2d.velocity = Vector2.down * ballSpeed; --> Esto lo pasamos al metodo de Lanzar la bola que encontramos abajo para que se lance no al iniciar la partida
        // si no cada vez que pulsemos el boton o que queramos hacerlo

        _gameManager = FindObjectOfType<GameManager>();
    }

    // Cambiamos el metodo Update a FixedUpdate ya que con el DeltaTime no queremos que cambie cada frame si no tan
    // rapido como sea posible
    void FixedUpdate()
    {
        currentVelocity = rigidbody2d.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision = " + collision.transform.name);
        
        //Pagina 156 - Unity 2022:Aprende a desarrolla videojuegos
        // Con reflext hacemos de la CurrentVelocity como direccion inicial y sumandole la normal damos la 
        // direccion resultante
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        rigidbody2d.velocity = moveDirection;

        if (collision.transform.CompareTag("DeathLimit"))
        {
            FindObjectOfType<AudioController>().PlaySfx(loseLife);
            
            if (_gameManager!=null)
            {
                _gameManager.PlayerLives--;
            }
        }
        
        if (collision.transform.CompareTag("Player"))
        {
            //Siendo el player el paddle
            
            FindObjectOfType<AudioController>().PlaySfx(paddleBounce);
        }
        if (collision.transform.CompareTag("Brick"))
        {
            FindObjectOfType<AudioController>().PlaySfx(bounce);
        }
    }

    public void LaunchBall()
    {
        //Esto es para hacer que la bola no sea hija del Paddle una vez la lancemos
        //Será hija para poder moverla junto al paddle pero despues ya no lo será.
        transform.SetParent(null);
        
        rigidbody2d.velocity = Vector2.down * ballSpeed;
    }

    public void ResetBall()
    {
        //Eliminar velocidad actual de la bola
        rigidbody2d.velocity = Vector3.zero;
        
        //La volvemos a hacer hija del Paddle
        Transform paddle = GameObject.Find("Paddle").transform;
        transform.SetParent(paddle);
        
        //Damos posicion a la bola con la posicion del Paddle y la ponemos un poco más arriba
        Vector2 ballposition = paddle.position;
        ballposition.y += 0.6f;
        transform.position = ballposition;
        
        //Indicamos al game manager que la bola no está en juego en ese momento
        _gameManager.BallOnPlay = false;
        
    }
}
