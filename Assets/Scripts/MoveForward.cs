using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveForward : MonoBehaviour
{
    public float speed = 20f;
    public InputActionAsset InputActions;
    private InputActionMap uiMap;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        uiMap = InputActions.FindActionMap("UI");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!uiMap.enabled)
        {
            animator.speed = 1;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            animator.speed = 0;
        }
    }
}
