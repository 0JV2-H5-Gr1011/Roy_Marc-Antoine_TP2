using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class Niveau1Collection : MonoBehaviour
{
    private int currentItems = 0;
    private int totalCollected = 0;
    public TMP_Text conteurItemsText;
    public TMP_Text score;
    private bool canPickup = true;
    private List<GameObject> collectedItems = new List<GameObject>();
    public GameObject Poubelle;
//--------------------------------------------------------------------------------------------------------
    private void Start()
    {
        UpdateCounterUI();
        UpdateTotalCollectedUI();
    }

    private void Update()
    {
        TryPickupItem();
        CheckForTrashCan();
        CheckForLevelTransition();
    }
//--------------------------------------------------------------------------------------------------------
    private void TryPickupItem()
    {
        if (!canPickup) return;

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
        yield return new WaitForSeconds(1f);
        canPickup = true;
    }
//--------------------------------------------------------------------------------------------------------
    private void UpdateCounterUI()
    {
        conteurItemsText.text = "Items : " + currentItems + "/3";
    }

    private void UpdateTotalCollectedUI()
    {
        score.text = "Items total : " + totalCollected + "/6";
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
    //--------------------------------------------------------------------------------------------------------  
    private void CheckForLevelTransition()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, 1f);  // ✅ Sphere detects nearby objects
        foreach (Collider obj in nearbyObjects)
        {
            if (obj.CompareTag("Lvl2") && totalCollected >= 6) 
            {
                Debug.Log("🚀 Entering Level 2...");
                SceneManager.LoadScene("Niveau2");  
                return;  
            }
        }
    }
}