using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemi1 : MonoBehaviour
{

    [SerializeField] private Transform _cible;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        // _agent.SetDestination(_cible.position);
    }

    // Update is called once per frame
    void Update()
    {
        BougerAgent();
    }

    void BougerAgent()
    {
        _agent.SetDestination(_cible.position);
    }

}
