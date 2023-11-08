using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator Transitions;
    public float TransitionTime = 0.3f;


    IEnumerator LoadLevel(int levelIndex)
    {
        Transitions.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
