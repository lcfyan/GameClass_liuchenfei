using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private CharacterController cc;
    [Header("移动参数")]
    public float moveSpeed;
    private float horizontalMove, verticalMove;
    private Vector3 dir;

    public GameObject myBag;
    bool isOpen;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveCharacter();
        OpenMyBag();
    }

    void FixedUpdate()
    {
        // Use FixedUpdate for character movement physics if necessary
    }

    void MoveCharacter()
    {
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);
    }

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
}
