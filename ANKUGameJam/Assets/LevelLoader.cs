using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator gecis;
    public float gecis_suresi=1f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }       
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        gecis.SetTrigger("baslat");
        yield return new WaitForSeconds(gecis_suresi);
        SceneManager.LoadScene(levelIndex);

    }
}
