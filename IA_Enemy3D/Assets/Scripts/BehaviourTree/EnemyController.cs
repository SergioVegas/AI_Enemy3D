using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
        AttackDistance = GetComponent<CapsuleCollider>().radius;
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
    public int AttackDamage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(AttackDamage);
                Debug.Log("Enemigo atacó al jugador!");
            }
        }
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
        ChangeState();
    }
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            HP = 0;
            die.check = true;
            ChangeState();
            Debug.Log("Enemigo eliminado por comando (P)");
        }

        if (currentState != null)
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
