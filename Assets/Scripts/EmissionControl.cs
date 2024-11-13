using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmissionControl : MonoBehaviour
{

    public InputActionAsset gameInput;

    InputAction trailModifier;

    [SerializeField] EmitterSpectrometer leftEmitter;
    [SerializeField] EmitterSpectrometer rightEmitter;
    [SerializeField] EmitterSpectrometer ovaloEmitter;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 2;
    }
    void Start()
    {
        gameInput.FindActionMap("Game").Enable();

        gameInput.FindActionMap("Game").FindAction("Left").performed += TurnLeft;
        gameInput.FindActionMap("Game").FindAction("Right").performed += TurnRight;
        gameInput.FindActionMap("Game").FindAction("Ovalo").performed += TurnOvalo;
        gameInput.FindActionMap("Game").FindAction("Trail").performed += Trails;
        gameInput.FindActionMap("Game").FindAction("Both").performed += TurnBoth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnBoth(InputAction.CallbackContext callback)
    {
        rightEmitter.emmit = false;
        leftEmitter.emmit = false;
    }
    public void TurnLeft(InputAction.CallbackContext callback)
    {
        rightEmitter.emmit = false;
        leftEmitter.emmit = true;
    }
    public void TurnRight(InputAction.CallbackContext callback)
    {
        leftEmitter.emmit = false;
        rightEmitter.emmit = true;
    }
    public void TurnOvalo(InputAction.CallbackContext callback)
    {
        ovaloEmitter.spectrometerSystem.Emit(100);
    }
    public void TurnBoth()
    {
        rightEmitter.emmit = false;
        leftEmitter.emmit = false;
    }
    public void TurnLeft()
    {
        rightEmitter.emmit = false;
        leftEmitter.emmit = true;
    }
    public void TurnRight()
    {
        leftEmitter.emmit = false;
        rightEmitter.emmit = true;
    }
    public void TurnOvalo()
    {
        ovaloEmitter.spectrometerSystem.Emit(100);
    }
    public void Trails(InputAction.CallbackContext callback)
    {
        if (callback.started) 
        {
            var trail = leftEmitter.spectrometerSystem.trails;
            trail.enabled = true;
            trail = rightEmitter.spectrometerSystem.trails;
            trail.enabled = true;
            trail = ovaloEmitter.spectrometerSystem.trails;
            trail.enabled = true;
        }
        if (callback.canceled) 
        {
            var trail = leftEmitter.spectrometerSystem.trails;
            trail.enabled = false;
            trail = rightEmitter.spectrometerSystem.trails;
            trail.enabled = false;
            trail = ovaloEmitter.spectrometerSystem.trails;
            trail.enabled = false;
        }
    }
}
