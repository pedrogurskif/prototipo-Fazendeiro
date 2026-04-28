using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhostPower : MonoBehaviour
{
    public InputActionAsset InputActions;
    private InputAction powerAction;
    private InputAction fireAction;
    [SerializeField] private float timer = 2f;
    private float maxGhostDuration = 2f;
    public GameObject playerModel;
    private bool canGhost = true;

    void Awake()
    {
        powerAction = InputSystem.actions.FindAction("Power");
        fireAction = InputSystem.actions.FindAction("Fire");
    }

    void Start()
    {
       
    }

    void Update()
    {
        if(powerAction.WasPressedThisFrame() && canGhost)
        {
            StartCoroutine(StartGhost());
        }

        else if(powerAction.WasReleasedThisFrame())
        {
            StartCoroutine(EndGhost());
        }

    }

    private IEnumerator GhostCoroutine()
    {
        while(true)
        {
            if(powerAction.IsPressed() && timer >= 0f)
            {
                gameObject.tag = "PlayerGhost";
                playerModel.SetActive(false);
                timer -= Time.deltaTime;
                fireAction.Disable();
            }
            if(!powerAction.IsPressed() || timer < 0f)
            {
                gameObject.tag = "Player";
                playerModel.SetActive(true);
                fireAction.Enable();
            }
            yield return null;
        }
    }

    private IEnumerator StartGhost()
    {
        gameObject.tag = "PlayerGhost";
        playerModel.SetActive(false);
        fireAction.Disable();
        yield return new WaitForSeconds(maxGhostDuration);

        StartCoroutine(EndGhost());
    }

    private IEnumerator EndGhost()
    {
        StopCoroutine(StartGhost());
        canGhost = false;
        gameObject.tag = "Player";
        playerModel.SetActive(true);
        fireAction.Enable();
        yield return new WaitForSeconds(maxGhostDuration);

        canGhost = true;
        StopCoroutine(EndGhost());
    }
}
