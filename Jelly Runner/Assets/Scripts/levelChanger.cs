using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour {

    public Animator animator;

    private int leveltoLoad;

    // Update is called once per frame


    public void FadetoNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            FadetoLevel(SceneManager.GetActiveScene().buildIndex + 1);

        }
       
    }

    public void FadetoLevel(int levelIndex)
    {
        leveltoLoad = levelIndex;
        animator.SetTrigger("Fade_in2");

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(leveltoLoad); 
    }
}
