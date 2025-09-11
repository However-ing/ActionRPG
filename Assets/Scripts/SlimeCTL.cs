using UnityEngine;
using UnityEngine.AI;

public class SlimeCTL : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
