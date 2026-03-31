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

    void Start()
    {
        StartCoroutine(GhostCoroutine());
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
                print(timer);
            }
            if(!powerAction.IsPressed() || timer < 0f)
            {
                gameObject.tag = "Player";
                playerModel.SetActive(true);
                fireAction.Enable();
                Regeneration();
            }
            yield return null;
        }
    }

    void Regeneration()
    {
        if(timer <= 2f)
        {
            timer += Time.deltaTime;
        }
        if(timer > 2f)
        {
            timer = 2f;
        }
    }
}
