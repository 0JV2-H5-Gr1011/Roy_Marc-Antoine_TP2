using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;
using StarterAssets;
using Unity.Mathematics;

public class Niveau2Collection : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private int currentItems = 0;
    private int totalCollected = 0;
    public TMP_Text conteurItemsText;
    public TMP_Text score;
    private bool canPickup = true;
    private List<GameObject> collectedItems = new List<GameObject>();
    public GameObject Poubelle;
    //--------------------------------------------------------------------------------------------------------
    private void Awake()
    {
        _input = FindAnyObjectByType<StarterAssetsInputs>();
    }

    private void Start()
    {
        UpdateCounterUI();
        UpdateTotalCollectedUI();
    }

    private void Update()
    {
        if (_input.pickup && canPickup)
        {
            TryPickupItem();
            _input.pickup = false;
        }

        CheckForTrashCan();
    }
    //--------------------------------------------------------------------------------------------------------
    private void TryPickupItem()
    {
        Collider[] trashItems = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider trash in trashItems)
        {
            if (trash.CompareTag("TrashItem") && currentItems < 3)
            {
                currentItems++;
                collectedItems.Add(trash.gameObject);

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
        yield return new WaitForSeconds(0.5f);
        canPickup = true;
    }
    //--------------------------------------------------------------------------------------------------------
    private void UpdateCounterUI()
    {
        conteurItemsText.text = "Items : " + currentItems + "/3";
    }

    private void UpdateTotalCollectedUI()
    {
            score.text = "Items total : " + totalCollected + "/12";
    }
    //--------------------------------------------------------------------------------------------------------
    public void DepositItems()
    {
        totalCollected += collectedItems.Count;
        collectedItems.Clear();
        currentItems = 0;
        UpdateTotalCollectedUI();
        UpdateCounterUI();
    }

    private void CheckForTrashCan()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider obj in nearbyObjects)  
        {
            if (obj.gameObject.name == "Poubelle")
            {
                DepositItems();
                return;
            }
        }
    }
}