using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "Scriptable Objects/IdleState")]
public class IdleState : Node
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
        Debug.Log("me toco el ano");
    }
    public override void OnExit(EnemyController ec)
    {
    }
}
