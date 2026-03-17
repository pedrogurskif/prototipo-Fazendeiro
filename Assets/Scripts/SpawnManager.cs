using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15f;
    private float spawnPositionZ = 20f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    public InputActionAsset InputActions;
    private InputAction PausePlayer;
    private InputAction PauseUI;

    void Start()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
        PausePlayer = InputSystem.actions.FindAction("PausePlayer");
        PauseUI = InputSystem.actions.FindAction("PauseUI"); 
    }

    void Update()
    {
        if(PausePlayer.WasPressedThisFrame())
        {
            Pause();
        }
        if(PauseUI.WasPressedThisFrame())
        {
            Unpause();
        }
    }

    void SpawnAnimal()
    {

        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 randomPosition = new Vector3(Random.Range
         (-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        Instantiate(animalPrefabs[animalIndex], randomPosition,
         animalPrefabs[animalIndex].transform.rotation);
    }

    void Pause()
    {
        CancelInvoke("SpawnAnimal");
    }

    void Unpause()
    {
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval);
    }
}
