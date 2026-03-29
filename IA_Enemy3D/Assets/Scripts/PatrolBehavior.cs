using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] public Transform _point1;
    [SerializeField] public Transform _point2;
    [SerializeField] public Transform _point3;

    private NavMeshAgent _navAgent;
    public float Speed = 3.5f;
    public float stoppingDistance = 0.5f;

    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = Speed;
        
        _waypoints = new Transform[] { _point1, _point2, _point3 };
    }

    public void Patrol()
    {
        if (_waypoints.Length == 0 || _waypoints[0] == null) return;

        _navAgent.isStopped = false;

        if (!_navAgent.pathPending && _navAgent.remainingDistance <= _navAgent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            _navAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
        }
        else if (!_navAgent.hasPath)
        {
            _navAgent.SetDestination(_waypoints[_currentWaypointIndex].position);
        }
    }

    public void StopPatrol()
    {
        if (_navAgent != null)
        {
            _navAgent.isStopped = true;
        }
    }
}
