using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    [Header("Patrulla")]
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    [Header("Deteccion")]
    public float rangoPersecucion = 7f;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }

        IrAlSiguientePunto();
    }

    void Update()
    {
        if (player == null) return;

        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador <= rangoPersecucion)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                IrAlSiguientePunto();
            }
        }
    }

    void IrAlSiguientePunto()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoPersecucion);
    }
}

