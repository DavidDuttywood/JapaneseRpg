using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public Animator animator;
    public SceneTransitionManager stm;
    public void NewGame()
    {
        GameManager.instance.ClearSaveLogs();
        LoadLevel("BaseMechanicsSandbox");
    }

    public void LoadGame()
    {
        //need a new save value in GameManager to remember which scene
        stm.LoadLevel("BaseMechanicsSandbox");
    }

    public void LoadLevel(string targetScene)
    {
        StartCoroutine(StartGame(targetScene));
    }

    IEnumerator StartGame(string targetScene)
    {
        animator.SetTrigger("buttonPressed");
        yield return new WaitForSeconds(3f);
        stm.LoadLevel("BaseMechanicsSandbox");
    }
}
