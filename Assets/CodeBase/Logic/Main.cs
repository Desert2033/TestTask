using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EdCon.MiniGameTemplate
{
    public class Main : MonoBehaviour
    {
        private const string NextSceneName = "CustomizationScene";

        [SerializeField] private Button _nextMenuButton;

        private void OnEnable() => 
            _nextMenuButton.onClick.AddListener(OnLoadScene);

        private void OnDisable() => 
            _nextMenuButton.onClick.RemoveListener(OnLoadScene);

        public void OnLoadScene() => 
            SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
    }
}
