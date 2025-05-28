using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.Burst.CompilerServices;
using StarterAssets;

public class PickupItem : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private int currentItems = 0;
    private int totalCollected = 0;
    public TMP_Text conteurItemsText;
    private bool canPickup = true;

    private void Awake()
    {
        _input = FindAnyObjectByType<StarterAssetsInputs>();    
    }

    private void Start()
    {
        UpdateCounterUI();
    }

    private void Update()
    {
        if (_input.pickup && canPickup)
        {
            TryPickupItem();
            _input.pickup = false;
        }
    }

    private void TryPickupItem()
    {
        Collider[] trashItems = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider trash in trashItems)
        {
            if (trash.CompareTag("TrashItem") && currentItems < 3)
            {
                currentItems++;
                totalCollected++;

                Debug.Log("Picked up item! current count: " + currentItems);

                Destroy(trash.gameObject);
                UpdateCounterUI();
                StartCoroutine(PickupCooldown());

                break;
            }
        }
    }

    private IEnumerator PickupCooldown()
    {
        canPickup = false;
        yield return new WaitForSeconds(2f);
        canPickup = true;
        Debug.Log("cooldown done!");
    }

    private void UpdateCounterUI()
    {
        conteurItemsText.text = "Items : " + currentItems + "/3";
    }
}