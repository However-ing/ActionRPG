using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SlimeController : MonoBehaviour
{
 
    NavMeshAgent agent;
    public GameObject player;

    public float stopDistance = 2f;
    public float attackDamage = 10f;

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
