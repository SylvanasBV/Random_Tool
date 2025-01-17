using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerPhysics;
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] float moveInput;
    [SerializeField]  float turnInput;

    void Start()
    {
        // Declarar el rigidbd del objeto
        playerPhysics = GetComponent<Rigidbody>();
    }

    //Uso fix Update para tener una actualizacion de las variables fijas y un mejor manejo del movimiento con fisicas
    void FixedUpdate()
    {
        GetInput();
        Movimiento();
        Rotacion();
    }

    /// <summary>
    /// Obtengo las entradas de los ejes definidos en el Input Manager
    /// </summary>
    /// 
    void GetInput()
    {
        //Establesco la variable que se actualizara el movimiento Horizontal
        moveInput = Input.GetAxis("Vertical");
        //Establesco la variable que se actualizara el movimiento Vertical
        turnInput = Input.GetAxis("Horizontal");
    }

    void Movimiento()
    {
        //Movimiento aplicando las fuerzas de forma local para movimiento horizontal 
        playerPhysics.AddRelativeForce(Vector3.forward * moveInput * speed, ForceMode.Force);
    }

    void Rotacion()
    {
      //verifico la cantidad de que se va a aplicar a la rotacion del jugador
      float turn = turnInput * turnSpeed * Time.fixedDeltaTime;
      //se ingresa el valor de la fuerza para que pueda ser identificado como una orientacion  
      Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
      //se aplica la rotacion calculado a el orientacion actual del jugador
      playerPhysics.MoveRotation(playerPhysics.rotation * turnRotation);
    }
}
