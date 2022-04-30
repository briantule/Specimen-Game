using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int sceneToLoad = -1;
    // public void OnTriggeredEnter(PlayerController player)
    // {
    //     StartCoroutine(SwitchScene());
    // }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("test");
        StartCoroutine(SwitchScene());
    }   

    IEnumerator SwitchScene()
    {
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }
}
