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
        LoadLevel("NewGameCinematic");
    }

    public void LoadGame()
    {
        LoadLevel("BaseMechanicsSandbox");
    }

    public void DebugGame()
    {
        GameManager.instance.InitObjectiveProgress();
        LoadLevel("BaseMechanicsSandbox");
    }

    public void LoadLevel(string targetScene)
    {
        StartCoroutine(StartGame(targetScene));
    }

    IEnumerator StartGame(string targetScene)
    {
        GameManager.instance.InitObjectiveProgress();
        animator.SetTrigger("buttonPressed");
        yield return new WaitForSeconds(3f);
        stm.LoadLevel(targetScene);
    }
}
