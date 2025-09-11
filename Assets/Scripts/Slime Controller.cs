using UnityEngine;
using UnityEngine.AI;

public class SlimeController : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
