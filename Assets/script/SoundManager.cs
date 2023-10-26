using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public static SoundManager Instance
    {
        get { return instance; }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 添加AudioSource组件并设置为循环播放
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
