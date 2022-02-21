using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadToScene (string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
