using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToScene : MonoBehaviour
{
    private bool hasCollided = false;

    void OnTriggerEnter(Collider other)
    {
        // 检查是否与目标物体碰撞，并且尚未切换场景
        if (other.CompareTag("B") && !hasCollided)
        {
            // 设置标志以避免多次切换
            hasCollided = true;

            // 切换到场景 B
            SceneManager.LoadScene("B");
        }
    }
}