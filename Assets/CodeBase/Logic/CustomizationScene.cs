using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace EdCon.MiniGameTemplate
{
    public class CustomizationScene : MonoBehaviour
    {
        private const string NextSceneName = "MainScene";

        [SerializeField] private Button _backButton;

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnLoadScene);
        }

        private void OnDisable() => 
            _backButton.onClick.RemoveListener(OnLoadScene);

        public void OnLoadScene() => 
            SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
    }
}
