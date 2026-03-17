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
    public GameObject playerModel;

    void Awake()
    {
        powerAction = InputSystem.actions.FindAction("Power");
        fireAction = InputSystem.actions.FindAction("Fire");
    }

    void Update()
    {
        Ghost();
        if(timer > 2)
        {
            timer = 2;
        }
    }

    void Ghost()
    {
        if(powerAction.IsPressed() && timer >= 0f)
        {
            playerModel.SetActive(false);
            timer -= Time.deltaTime;
            fireAction.Disable();
            print(timer);
        }
        if(!powerAction.IsPressed() || timer < 0f)
        {
            playerModel.SetActive(true);
            fireAction.Enable();
            Regeneration();
        }
    }

    void Regeneration()
    {
        timer += Time.deltaTime;
    }
}
