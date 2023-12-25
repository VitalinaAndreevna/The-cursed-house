using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;


[RequireComponent(typeof(Light2D))]
public class WorldLight : MonoBehaviour
{
    private Light2D light;

    [SerializeField]
    private WorldTime.WorldTime worldTime;

    [SerializeField]
    private Gradient gradient;

    private void Awake()
    {
        light = GetComponent<Light2D>();
        worldTime.WorldTimeChanged += OnWorldTimeChanged;

    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        light.color = gradient.Evaluate(PercentOfDay(newTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTime.WorldTimeConstants.MinutesInDay / WorldTime.WorldTimeConstants.MinutesInDay;
    }
}