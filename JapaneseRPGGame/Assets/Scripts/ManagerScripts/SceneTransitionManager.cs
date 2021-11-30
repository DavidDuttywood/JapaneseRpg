using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource sceneTrack;

    public void Start()
    {
        if (sceneTrack != null && sceneTrack.clip != GameManager.instance.music.clip)
        {

            GameManager.instance.ChangeMusic(sceneTrack.clip);
        }
    }

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
