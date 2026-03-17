using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveForward : MonoBehaviour
{
    public float speed = 20f;
    public InputActionAsset InputActions;
    private InputActionMap uiMap;
    // Start is called before the first frame update
    void Awake()
    {
        uiMap = InputActions.FindActionMap("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if(!uiMap.enabled)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
