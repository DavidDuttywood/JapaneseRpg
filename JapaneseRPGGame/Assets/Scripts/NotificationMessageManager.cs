using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationMessageManager : MonoBehaviour
{

    public GameObject notificationMessage;
    public string sceneName;
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        notificationMessage = GameObject.Find("NotificationMessage");
        notificationMessage.SetActive(false);

        GameManager.instance.nmm = this;

        if(sceneName != null)
            ShowNotifcation(sceneName);

    }
    public void ShowNotifcation(string message)
    {
        notificationMessage.GetComponentInChildren<Text>().text = message;
        notificationMessage.SetActive(true);
        animator.SetTrigger("ShowNotification");
    }
}
