using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject prompt;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(Time.time + ":进入该触发器的对象是：" + other.gameObject.name);
        Show();
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(Time.time + "离开触发器的对象是：" + other.gameObject.name);
        Hide();
    }

    void Show()
    {
        // 显示UI界面
        if (prompt != null)
        {
            prompt.SetActive(true);
        }
    }

    void Hide()
    {
        // 隐藏UI界面
        if (prompt != null)
        {
            prompt.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
