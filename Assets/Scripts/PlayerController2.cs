using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pausePlayerAction;
    private InputAction pauseUIAction;
    private GameObject pauseBg;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Pause() // a
    {
        InputActions.FindActionMap("UI").Enable();
        InputActions.FindActionMap("Player").Disable();
        pauseBg.SetActive(true);

    }

    private void Unpause() 
    {
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();
        pauseBg.SetActive(false);
    }

    private void Awake()
    {
        pauseBg = GameObject.Find("PauseBackground");
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");
        pausePlayerAction = InputSystem.actions.FindAction("PausePlayer");
        pauseUIAction = InputSystem.actions.FindAction("PauseUI"); // só despausa se o jogo estiver pausado
        Unpause();
    }

    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        if(fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if(pausePlayerAction.WasPressedThisFrame())
        {
            Pause();
        }
        if(pauseUIAction.WasPressedThisFrame())
        {
            Unpause();
        }
    }
}
