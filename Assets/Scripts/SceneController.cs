using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneLevels()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSceneLevelOne()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSceneLevelTwo()
    {
        SceneManager.LoadScene(3);
    }
}
