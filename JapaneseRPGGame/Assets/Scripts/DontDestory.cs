using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    public string objectID;
    private void Awake()
    {
        objectID = name + transform.position.ToString();
    }

    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestory>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestory>()[i] != this)
            {
                if (Object.FindObjectsOfType<DontDestory>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }
}