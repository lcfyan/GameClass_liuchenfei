using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int sceneSwitch = 0;
    public int playerHealth = 100;

    private CharacterController characterController;
    private Animator animator;
    private StateMachine stateMachine;

    public float moveSpeed = 5.0f;
    public float attackCooldown = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        characterController = GetComponent <CharacterController>();
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        // 在角色管理器中处理其他逻辑，如生命值、游戏事件等

        // 在这里添加移动逻辑
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 dir = transform.forward * verticalMove + transform.right * horizontalMove;
        characterController.Move(dir * moveSpeed * Time.deltaTime);
    }

    // 在这里添加其他角色管理器的功能和逻辑
}
