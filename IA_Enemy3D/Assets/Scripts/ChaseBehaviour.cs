using UnityEngine.AI;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float Speed;
    private NavMeshAgent _navAgent;
    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = Speed;
    }
    public void Chase(Transform target)
    {
        _navAgent.isStopped = false;
        _navAgent.SetDestination(target.position);
    }
    public void Run(Transform target, Transform self)
    {
        _navAgent.isStopped = false;

        Vector3 runningAwayDirection = (self.position - target.position).normalized;

        Vector3 escapePoint = self.position + runningAwayDirection * 10f;

        _navAgent.SetDestination(escapePoint);
    }

    public void StopChasing()
    {
        _navAgent.isStopped = true;
    }
}
