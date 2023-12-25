using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class WorldTimeWatcher : MonoBehaviour
{
    [SerializeField]
    private WorldLight worldLight;

    [SerializeField]
    private WorldTime.WorldTime worldTime;

    [SerializeField]
    private List<Schedule> schedule;

    [Serializable]
    private class Schedule
    {
        public int Hour;
        public int Minute;
        public UnityEvent action;
    }

    private void CheckSchedule(object sender, TimeSpan newTime)
    {
        var _schedule = schedule.FirstOrDefault(s => s.Hour == newTime.Hours && s.Minute == newTime.Minutes);

        _schedule?.action?.Invoke();
    }

    private void Start()
    {
        worldTime.WorldTimeChanged += CheckSchedule;
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= CheckSchedule;
    }
}
