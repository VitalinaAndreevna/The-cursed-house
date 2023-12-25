using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;


public class WorldLight : MonoBehaviour
{
    [SerializeField] private Gradient gradient;
    private Light2D light;
    private float startTime;
    public float duration;

    private void Awake()
    {
        startTime = Time.time;
        light = GetComponent<Light2D>();
    }

    private void Update()
    {
        float timeElapsed = Time.time - startTime;
        float persetage= Mathf.Sin(f: timeElapsed / duration * Mathf.PI * 2) * 0.5f + 0.5f;
        persetage = Mathf.Clamp01(persetage);

        light.color = gradient.Evaluate(persetage);
    }
}
