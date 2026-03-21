using UnityEngine;

[CreateAssetMenu(fileName = "RunState", menuName = "Scriptable Objects/RunState")]
public class RunState : Node
{
    public override bool EnterCondition(EnemyController ec)
    {
        return ec.run.check;
    }
    public override bool ExitCondition(EnemyController ec)
    {
        return !ec.run.check || ec.die.check;
    }
    public override void OnStart(EnemyController ec)
    {
    }
    public override void OnUpdate(EnemyController ec)
    {
        base.OnUpdate(ec);
        ec.GetComponent<ChaseBehaviour>().Chase(ec.transform, ec.target.transform);
        Debug.Log("huyo de tu ano");
    }
    public override void OnExit(EnemyController ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.chase.name, ec.chase.check);
        // ec.GetComponent<ChaseBehaviour>().StopChasing();
    }
}
