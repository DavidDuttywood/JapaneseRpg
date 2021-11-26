using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationMessageManager : MonoBehaviour
{
    public GameObject notificationMessage;

    void Awake()
    {
        notificationMessage = GameObject.Find("NotificationMessage");
        notificationMessage.SetActive(false);
    }
    public void ShowNotifcation(string message)
    {
        notificationMessage.GetComponentInChildren<Text>().text = message;
        notificationMessage.SetActive(true);
    }
}
