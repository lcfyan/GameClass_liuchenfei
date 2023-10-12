using UnityEngine;

public class foodstep : MonoBehaviour
{
    public AudioClip footstepSound; // 脚步声音效
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 用于在动画事件中触发的函数
    public void PlayStep()
    {
        audioSource.clip = footstepSound;
        audioSource.Play();
    }
}
