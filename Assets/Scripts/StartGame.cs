using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class StartGame : MonoBehaviour
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}