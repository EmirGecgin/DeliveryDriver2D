using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int time;
    [SerializeField] private GameObject lostText;
    public DriverController driverController;

    private void Start()
    {
        StartCoroutine("TimeCounter");
        driverController = FindObjectOfType<DriverController>();
    }

    private void Update()
    {
        TimeIsDone();
    }
    private void TimeIsDone()
    {
        if (time == 0)
        {
            driverController.gameObject.SetActive(false);
            lostText.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);
        }
    }
    IEnumerator TimeCounter()
    {
        while (true)
        {
            timerText.text = $"{time/60:00}:{time%60:00}";
            time--;
            yield return new WaitForSeconds(1);
        }
    }
}
