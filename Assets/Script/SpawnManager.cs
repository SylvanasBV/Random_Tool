using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /* Declaro las variables con los objetos
      Y los puntos donde se ubicaran los objetos */
    public GameObject[] objectsSpawn;
    public Transform[] spawnPoints;


    void Start()
    {
        SpawnObjectsRandomly();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Spawn de los objetos a recojer
    /// </summary>
    void SpawnObjectsRandomly()
    {
        // Creo una lista temporal con todos los puntos de spawn
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < objectsSpawn.Length; i++)
        {
            // Verificar si aún quedan puntos de spawn disponibles
            if (availableSpawnPoints.Count == 0)
            {
                break; // Salir del bucle si no hay más puntos
            }

            // Elegir un índice aleatorio en la lista de puntos disponibles
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);

            // Instanciar el objeto en el punto seleccionado
            Instantiate(objectsSpawn[i], availableSpawnPoints[randomIndex].position, objectsSpawn[i].transform.rotation);

            // Eliminar el punto utilizado para evitar repetición
            availableSpawnPoints.RemoveAt(randomIndex);
        }
    }

}
