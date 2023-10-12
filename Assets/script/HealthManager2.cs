using UnityEngine;
using UnityEngine.UI;
public class HealthManager2 : MonoBehaviour
{
    private int playerHealth = 0; // 初始血量
    public Text healthText; // 用于显示血量的UI文本
    private PlayerDataManager playerDataManager;

    void Start()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>(); // 获取PlayerDataManager的引用
        if (playerDataManager != null)
        {
            playerHealth = playerDataManager.playerHealth; // 获取血量值
        }

        UpdateHealthUI(); // 初始时更新UI显示
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible2")) // 碰到的物体是否是"Collectible"标签
        {
            playerHealth += 15; // 增加血量
            UpdateHealthUI(); // 更新UI显示
            SavePlayerHealth(); // 保存玩家血量
            Destroy(other.gameObject); // 销毁碰到的物体
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Money: " + playerHealth.ToString();
        }
    }

    void SavePlayerHealth()
    {
        if (playerDataManager != null)
        {
            playerDataManager.playerHealth = playerHealth; // 保存玩家血量到PlayerDataManager
        }
    }
}

