using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeReference] GameObject exitSpot;
    [SerializeField] float exitFreezeInterval = 0.1f;
    [SerializeField] Vector3 exitPositionOffset = new Vector3(0, 0.01f, 0);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = exitSpot.transform.position + exitPositionOffset;
            other.transform.rotation = exitSpot.transform.rotation;
            StartCoroutine("ReactivateControl", other.gameObject);
        }
    }

    IEnumerator ReactivateControl(GameObject controller)
    {
        yield return new WaitForSeconds(exitFreezeInterval);
        controller.SetActive(true);

        CharacterController charController = controller.GetComponent<CharacterController>();
            if (charController != null)
            {
                charController.enabled = false;  
                yield return new WaitForSeconds(exitFreezeInterval);  // ✅ Allow brief reset time
                charController.enabled = true;  // 🔄 Re-enable movement!
                Debug.Log("✅ CharacterController unlocked after teleport!");
            }
    }


}
