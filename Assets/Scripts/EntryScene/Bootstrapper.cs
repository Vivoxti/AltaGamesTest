using Core;
using Global;
using UnityEngine;
using Zenject;

namespace EntryScene
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneReference initialScene;
        
        private SceneLoader _sceneLoader;
        
        [Inject]
        private void Inject(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Initialize();
        }

        private void Initialize()
        {
            var initialSceneName = initialScene.GetSceneName();
            _sceneLoader.LoadSceneInstantly(initialSceneName);
        }
    }
}