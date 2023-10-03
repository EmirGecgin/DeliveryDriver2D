using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DriverController : MonoBehaviour
{
    [SerializeField] private float turningSpeed;
    [SerializeField] private float verticalSpeed;
    private float _horizontalMovement, _verticalMovement;
    [SerializeField] private float boostSpeed = 22, slowSpeed = 12;
    private int _carHealth = 100,_carDamage=4;
    [SerializeField] private TextMeshProUGUI carHealthText;
    [SerializeField] private GameObject lostPanel,timePanel;

    private void Start()
    {
        carHealthText.text = _carHealth.ToString();
    }
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal")*turningSpeed*Time.deltaTime;
        _verticalMovement = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        Drive();
        HealthIsZero();
    }
    private void Drive()
    {
        transform.Rotate(0,0,-_horizontalMovement);
        transform.Translate(0,_verticalMovement,0);
    }
    private void HealthIsZero()
    {
        if (_carHealth == 0)
        {
            gameObject.SetActive(false);
            lostPanel.gameObject.SetActive(true);
            timePanel.gameObject.SetActive(false);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boost"))
        {
            verticalSpeed = boostSpeed;

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boost"))
        {
            verticalSpeed = 16;

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        _carHealth -= _carDamage;
        carHealthText.text = _carHealth.ToString();
    }
}
