using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int sceneSwitch = 0;
    public int playerHealth = 100;

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
}