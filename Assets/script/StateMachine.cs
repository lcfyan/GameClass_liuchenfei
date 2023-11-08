using System.Collections;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float moveSpeed = 5.0f;
    public float attackCooldown = 1.0f;
    private bool canAttack = true;


    private enum PlayerState
    {
        Idle,
        Walk,
        attack
    }

    private PlayerState currentState = PlayerState.Idle;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent <Animator>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                UpdateIdleState();
                break;
            case PlayerState.Walk:
                UpdateWalkingState();
                break;
            case PlayerState.attack:
                UpdateAttackingState();
                break;
        }
    }

    private void UpdateIdleState()
    {
        // Idle状态的逻辑
        animator.SetBool("IsWalking", false);

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            animator.SetTrigger("attack");
            currentState = PlayerState.attack;
            StartCoroutine(AttackCooldown());
        }
        else if (IsMoving())
        {
            currentState = PlayerState.Walk;
        }
    }

    private void UpdateWalkingState()
    {
        // Walking状态的逻辑
        animator.SetBool("IsWalking", true);

        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            animator.SetTrigger("attack");
            currentState = PlayerState.attack;
            StartCoroutine(AttackCooldown());
        }
        else if (!IsMoving())
        {
            currentState = PlayerState.Idle;
        }
    }

    private void UpdateAttackingState()
    {
        // Attacking状态的逻辑
        // 在攻击状态中处理攻击的逻辑

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            currentState = PlayerState.Idle;
        }
    }

    private bool IsMoving()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        return !Mathf.Approximately(horizontalMove, 0f) || !Mathf.Approximately(verticalMove, 0f);
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
