using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryController : MonoBehaviour
{
    private bool isDeliveryTaken;
    [SerializeField] private Color32 hasDeliveryPackage = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 originalColorCar = new Color32(1, 1, 1, 1);
    private SpriteRenderer _spriteRenderer;
    private int _howManyDelivery;
    [SerializeField] private GameObject winText;
    [SerializeField] private TextMeshProUGUI deliveryText;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _howManyDelivery = 0;
        deliveryText.text = _howManyDelivery.ToString() + "/10";
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Delivery")&&!isDeliveryTaken)
        {
            Debug.Log("Delivery is taken by Crazy Car!");
            isDeliveryTaken = true;
            _spriteRenderer.color = hasDeliveryPackage;
            Destroy(col.gameObject,.15f);
        }

        if (col.gameObject.CompareTag("Customer")&&isDeliveryTaken)
        {
            Debug.Log("Delivery is taken by Customer!");
            isDeliveryTaken = false;
            _spriteRenderer.color = originalColorCar;
            _howManyDelivery++;
            deliveryText.text = _howManyDelivery.ToString() + "/10";
            print(_howManyDelivery);
            if (_howManyDelivery == 10)
            {
                Time.timeScale = 0;
                winText.gameObject.SetActive(true);
            }
        }
    }
}
