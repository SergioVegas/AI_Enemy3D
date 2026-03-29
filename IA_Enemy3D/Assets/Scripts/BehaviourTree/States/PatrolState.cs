using UnityEngine;

[CreateAssetMenu(fileName = "PatrolState", menuName = "Scriptable Objects/PatrolState")]
public class PatrolState : Node
{
    public override bool EnterCondition(EnemyController ec)
    {
        return true;
    }
    public override bool ExitCondition(EnemyController ec)
    {
        return ec.chase.check || ec.run.check || ec.attack.check;
    }
    public override void OnStart(EnemyController ec)
    {
    }
    public override void OnUpdate(EnemyController ec)
    {
        base.OnUpdate(ec);
        ec.GetComponent<PatrolBehavior>().Patrol();
        Debug.Log("Patrulla canina");
    }
    public override void OnExit(EnemyController ec)
    {
        ec.GetComponent<PatrolBehavior>().StopPatrol();
    }
}
