using UnityEngine;
using TMPro;

public class PickUpItems : MonoBehaviour
{
    // Declaro las variables de los objetos
    public Transform player; // Referencia al jugador
    public float interactionRange = 0.1f; // Distancia mínima para mostrar la "E"
    public Canvas interactionText; // Referencia al texto de interacción
    private bool isPlayerInRange = false; // Verificar si el jugador está cerca
    Collider objectCollider;

    void Start()
    {
        //Busco los componentes necesarios devido a que no estan permanentes en la scena
        player = GameObject.Find("Player").GetComponent<Transform>();
        interactionText = GetComponentInChildren<Canvas>();
        objectCollider = GetComponent<Collider>();
        if(interactionText != null)
        {
           interactionText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calcular la distancia entre el jugador y el objeto
        float distance = Vector3.Distance(transform.position, player.position);


        // Verificar si está dentro del rango de interacción
        if (distance <= interactionRange)
        {
            if (!isPlayerInRange)
            {
                ShowInteractionText();
                isPlayerInRange = true;
            }

            // Verificar si se presiona la tecla "E"
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
        else
        {
            if (isPlayerInRange)
            {
                HideInteractionText();
                isPlayerInRange = false;
            }
        }
    }

    // Mostrar el texto de interacción
    void ShowInteractionText()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(true);
        }
    }
    // Ocultar el texto de interacción
    void HideInteractionText()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    // Lógica al recoger el objeto
    void PickUp()
    {
        Debug.Log($"Picked up {gameObject.name}");
        // Aquí puedes agregar más lógica como agregar el objeto al inventario
        Destroy(gameObject); // Destruir el objeto después de recogerlo
    }
}
