using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public int sceneToLoad;
    public int sceneToUnload;
    private bool playerInDoor = false;
    public bool interior = false;

    private InteriorManager interiorManager;

    void Start()
    {
        GameObject[] system = GameObject.FindGameObjectsWithTag("System");
        interiorManager = system[0].GetComponent<InteriorManager>();
    }

    void Update()
    {
        if (playerInDoor && Input.GetKeyDown(KeyCode.E))
        {
            if (interior == false && !interiorManager.interior)
            {
                interiorManager.saveData.playerData.interior = !interiorManager.interior;
                interiorManager.saveData.SaveToJson();
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
            }
            else if (interior == true && interiorManager.interior)
            {
                interiorManager.saveData.playerData.interior = !interiorManager.interior;
                interiorManager.saveData.SaveToJson();
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