using UnityEngine;
using UnityEngine.UI;
public class HP : MonoBehaviour
{

    private int playerHealth = 100; // 初始血量
    public Text healthText; // 用于显示血量的UI文本
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>(); // 获取PlayerDataManager的引用
        if (playerManager != null)
        {
            playerHealth = playerManager.playerHealth; // 获取血量值
        }

        UpdateHealthUI(); // 初始时更新UI显示
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HP")) // 碰到的物体是否是"Collectible"标签
        {
            playerHealth += 10; // 增加血量
            UpdateHealthUI(); // 更新UI显示
            SavePlayerHealth(); // 保存玩家血量
            Destroy(other.gameObject); // 销毁碰到的物体
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + playerHealth.ToString();
        }
    }

    void SavePlayerHealth()
    {
        if (playerManager != null)
        {
            playerManager.playerHealth = playerHealth; // 保存玩家血量到PlayerDataManager
        }
    }
}