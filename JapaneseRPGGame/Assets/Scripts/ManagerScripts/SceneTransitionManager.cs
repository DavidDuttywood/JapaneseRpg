using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public Animator animator;

    public void LoadLevel(string targetScene)
    {
        StartCoroutine(TransitionScenes(targetScene));
    }

    IEnumerator TransitionScenes(string targetScene)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(targetScene);
    }
}
