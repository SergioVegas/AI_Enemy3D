using UnityEngine;

[CreateAssetMenu(fileName = "DieState", menuName = "Scriptable Objects/DieState")]
public class DieState : Node
{
    public override bool EnterCondition(EnemyController ec)
    {
        return ec.die.check;
    }
    public override bool ExitCondition(EnemyController ec)
    {
        return !ec.die.check;
    }
    public override void OnStart(EnemyController ec)
    {
        ec.GetComponent<Animator>().SetBool(ec.die.name, ec.die.check);
    }
    public override void OnUpdate(EnemyController ec)
    {
        base.OnUpdate(ec);
        Debug.Log("te me explotaste el ano");

    }
    public override void OnExit(EnemyController ec)
    {
       
    }
}
