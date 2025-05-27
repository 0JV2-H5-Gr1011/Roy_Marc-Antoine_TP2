using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private StarterAssets.StarterAssetsInputs playerInputs;
    // Start is called before the first frame update
    void Start()
    {
        playerInputs = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs != null && playerInputs.pickup && isPlayerInRange)
        {
            TryPickup(playerInputs.pickup);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupRange"))
        {
            isPlayerInRange = true;
            Debug.Log("isPlayerInRange = true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickupRange"))
        {
            isPlayerInRange = false;
            Debug.Log("isPlayerInRange = false");
        }
    }

    public void TryPickup(bool pickupPressed)
    {
        if (pickupPressed && isPlayerInRange)
        {
            Debug.Log("Item picked up");
            gameObject.SetActive(false);
        }
    }
}
