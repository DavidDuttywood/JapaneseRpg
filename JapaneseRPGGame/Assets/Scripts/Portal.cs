using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string destination;
    private SceneTransitionManager stm;

    void Start()
    {
        stm = FindObjectOfType<SceneTransitionManager>();
    }

    public void Interact()
    {
        stm.LoadLevel(destination);
    }
}
