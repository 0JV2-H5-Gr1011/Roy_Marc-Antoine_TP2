using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SlimeAI : MonoBehaviour
{
    public Transform player;  
    private NavMeshAgent agent;
    public float detectionRange = 5f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange) 
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath(); 
            }
        }

    }

private void OnTriggerEnter(Collider other )
{
    if (other.gameObject.CompareTag("Player"))  
    {
            SceneManager.LoadScene("finPerdu");
    }
}
}
