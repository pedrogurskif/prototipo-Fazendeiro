using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public InputActionAsset InputActions;
    public GameObject gameOverHUD;
    public GameObject heart1, heart2, heart3;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction ultimateAction;
    private InputAction pausePlayerAction;
    private InputAction pauseUIAction;
    private InputAction powerAction;
    private Coroutine ultimateCR;
    public GameObject pauseBg;
    public GameObject powerCar;
    public GameObject standardCar;
    private Vector3 spawnLocation = new Vector3(45, 0, 12);
    private float spawnInterval = 0;
    int hp = 3;
    public int maxHp = 3;
    private float ultimateCD = 0;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Pause() // só é chamada se o jogo estiver despausado
    {
        InputActions.FindActionMap("UI").Enable();
        InputActions.FindActionMap("Player").Disable();
        Time.timeScale = 0f;
        pauseBg.SetActive(true);
    }

    private void Unpause() // só é chamada se o jogo estiver pausado
    {
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();
        Time.timeScale = 1f;
        pauseBg.SetActive(false);
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");
        pausePlayerAction = InputSystem.actions.FindAction("PausePlayer");
        pauseUIAction = InputSystem.actions.FindAction("PauseUI"); 
        powerAction = InputSystem.actions.FindAction("Power");
        ultimateAction = InputSystem.actions.FindAction("Ultimate");
        Unpause();
    }

    void Update()
    {
        ultimateCD -= Time.deltaTime;
       // Debug.Log(ultimateCD);
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
            Shoot();
        }
        if(pausePlayerAction.WasPressedThisFrame())
        {
            Pause();
        }
        if(pauseUIAction.WasPressedThisFrame())
        {
            Unpause();
        }

        if(ultimateAction.WasPressedThisFrame())
        {
            if(ultimateCD <= 0)
            {
                ultimateCR = StartCoroutine(Ultimate());
                ultimateCD = 20;
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }

    IEnumerator Ultimate()
    {
        Instantiate(standardCar, spawnLocation, Quaternion.identity);
        spawnInterval = Random.Range(1.3f, 2f);
        yield return new WaitForSeconds(spawnInterval);
        Instantiate(powerCar, spawnLocation, Quaternion.identity);
        spawnInterval = Random.Range(1.3f, 2f);
        yield return new WaitForSeconds(spawnInterval);
        Instantiate(standardCar, spawnLocation, Quaternion.identity);
        StopCoroutine(ultimateCR);
    }

    public void Health(int change)
    {
        hp += change;
        if(hp>maxHp)
        {
            hp = maxHp;
        }
        if(hp==3)
        {
            heart3.SetActive(true);
        }
        else if(hp==2)
        {
            heart3.SetActive(false);
            heart2.SetActive(true);
        }
        else if(hp==1)
        {
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        else if(hp==0)
        {
            heart1.SetActive(false);
            Time.timeScale = 0;
            gameObject.SetActive(false);
            gameOverHUD.SetActive(true);
        }
    }
}
