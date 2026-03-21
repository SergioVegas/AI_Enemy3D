using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Condition attack;
    public Condition chase;
    public Condition die;
    public Condition run;
    public GameObject target;
    public float AttackDistance;
    public int HP = 5;
    public Node root;
    public Node currentState;
    private void Awake()
    {
        attack = new Condition("Attack");
        chase = new Condition("Chase");
        die = new Condition("Dead");
        run = new Condition("Run");
        AttackDistance = GetComponent<CircleCollider2D>().radius / 2f;
        ChangeState();
    }
    private void OnTriggerEnter(Collider collision)
    {
        chase.check = true;
        target = collision.gameObject;
    }
    private void OnTriggerExit(Collider collision)
    {
        chase.check = false;
    }
    private void OnTriggerStay(Collider collision)
    {
        attack.check = (target.transform.position - transform.position).magnitude <= AttackDistance;
    }
    private void OnCollisionEnter(Collision collision)
    {
        OnHurt();
    }
    public void OnHurt()
    {
        HP--;
        if (HP < 2)
            run.check = true;
        if (HP <= 0)
        {
            die.check = true;
        }
    }
    private void Update()
    {
        currentState.OnUpdate(this);
    }
    public void ChangeState()
    {
        StartCoroutine(WaitToTheEndOfFrame());
    }
    private IEnumerator WaitToTheEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        foreach (var node in root.children)
        {
            if (node.EnterCondition(this))
            {
                if (currentState != null)
                    currentState.OnExit(this);
                currentState = node;
                node.OnStart(this);
                break;
            }
        }
    }
}
