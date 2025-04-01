using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

public class StartTiming : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics; // Specify the characteristics of the controller (e.g., LeftHand, RightHand)
    public GameObject cube; // Reference to the cube GameObject
    private InputDevice targetDevice;

    public Color displayColor = Color.green; // Color to change the display to when the trackpad is pressed
    private Renderer cubeRenderer;
    private Material cubeMaterial;
    private float alpha = 1.0f; // Initial alpha value


    private void Start()
    {
        cube.SetActive(false);
        TryInitialize();
    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    private void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }

        // Check for trackpad press
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool trackpadPressed) && trackpadPressed)
        {
            OnTrackpadPressed();
        }
    }

    private void OnTrackpadPressed()
    {
        // Change the display color
        //Camera.main.backgroundColor = displayColor;
        cube.SetActive(true);
        // Debug.Log("Trackpad pressed! Display color changed to " + displayColor);
        // alpha = (alpha == 1.0f) ? 0.0f : 1.0f; // Toggle between 1.0 and 0.0
        // Color color = cubeMaterial.color;
        // color.a = alpha;
        // cubeMaterial.color = color;
        // Debug.Log("Cube alpha toggled to: " + alpha);
    }
}