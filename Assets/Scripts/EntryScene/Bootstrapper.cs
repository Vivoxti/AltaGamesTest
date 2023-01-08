using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntryScene
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneReference initialScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Initialize();
        }

        private void Initialize()
        {
            var initialSceneName = initialScene.GetSceneName();
            if (initialSceneName != SceneManager.GetActiveScene().name)
            {
                SceneManager.LoadScene(initialSceneName);
            }
        }
    }
}