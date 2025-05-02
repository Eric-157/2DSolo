using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public int sceneToLoad;
    public int sceneToUnload;
    private bool playerInDoor = false;
    public bool interior = false;

    void Update()
    {
        if (playerInDoor && Input.GetKeyDown(KeyCode.E))
        {
            if (interior == false)
            {
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
            }
            else if (interior == true)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(sceneToUnload), UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDoor = false;
        }
    }
}