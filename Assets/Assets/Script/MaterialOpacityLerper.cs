using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOpacityLerper : MonoBehaviour
{
    public Material material; // the material to modify
    public string shaderPropertyName = "Opacity"; // the name of the Shader Graph property controlling opacity
    public float startOpacity = 1.0f; // the starting opacity value
    public float endOpacity = 0.0f; // the ending opacity value
    public float lerpTime = 1.0f; // the time it takes to fully lerp between startOpacity and endOpacity

    private float currentOpacity; // the current opacity value
    private int shaderPropertyID; // the ID of the Shader Graph property controlling opacity
    private float timePassed = 0;
    private float lerpAmount;

    void Start()
    {
        // set initial opacity to startOpacity
        currentOpacity = startOpacity;
        material.SetFloat(shaderPropertyName, currentOpacity);

        // cache the property ID for better performance
        shaderPropertyID = Shader.PropertyToID(shaderPropertyName);
    }

    void Update()
    {
       
        // check if we need to lerp opacity
        if (currentOpacity != endOpacity)
        {
            timePassed += Time.deltaTime;
            // calculate lerp amount
            lerpAmount = timePassed / lerpTime;

            // lerp between currentOpacity and endOpacity
            currentOpacity = Mathf.Lerp(currentOpacity, endOpacity, lerpAmount);
            material.SetFloat(shaderPropertyID, currentOpacity);
        }
    }

    public void StartLerp()
    {
        // set currentOpacity to startOpacity 
        currentOpacity = startOpacity; 
    }

    public bool IsLerping()
    {
        return currentOpacity != endOpacity;
    }




}