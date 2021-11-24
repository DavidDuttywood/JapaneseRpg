using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public SceneTransitionManager stm;
    public void NewGame()
    {
        GameManager.instance.ClearSaveLogs();
        stm.LoadLevel("BaseMechanicsSandbox");
    }

    public void LoadGame()
    {
        //need a new save value in GameManager to remember which scene
        stm.LoadLevel("BaseMechanicsSandbox");
    }
}
