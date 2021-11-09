using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private bool canInteract;
    private Button interactButton;

    protected virtual void Start()
    {
        interactButton = GameManager.instance.interactButton;
        interactButton.onClick.AddListener(InteractButtonClick);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Interactor")
        {
            canInteract = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        canInteract = false;
    }

    void InteractButtonClick()
    {
        if (canInteract)
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {
        Debug.Log("hi");
    }
}
