using UnityEngine;

namespace Debug
{
    public class FpsDisplay : MonoBehaviour
    {
        [SerializeField] private Font font;
        [SerializeField] private bool showVersion = true;

        private float _deltaTime;

        private void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
        }

        private void OnGUI()
        {
            int width = Screen.width, height = Screen.height;

            var style = new GUIStyle();

            var rect = new Rect(80, 5, width, height * 50);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = height * 2 / 100;
            style.normal.textColor = new Color(1f, 1f, 0.49f);
            style.font = font;
            var fps = 1.0f / _deltaTime;
            var textVersion = $"  v.{Application.version}";
            var text = $"{fps:0.} FPS ";
            GUI.Label(rect, showVersion ? text + textVersion : text, style);
        }
    }
}