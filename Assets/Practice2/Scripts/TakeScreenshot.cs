using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice2
{
    public class TakeScreenshot : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _screenshotView;
        [SerializeField] private RenderTexture _renderTexture;

        private Material _viewMaterial;
        private Camera _camera;

        private void Start()
        {
            _viewMaterial = _screenshotView.material;
            _camera = Camera.main;
        }

        public void ScreenshotBtnPushed()
        {
            // スクリーンショットの取得
            var screenshot = Screenshot();

            // 画像をメッシュに表示
            _viewMaterial.SetTexture("_MainTex", screenshot);
        }

        // カメラ映像をTexture2Dに変換
        private Texture2D Screenshot()
        {
            // カメラ映像をRenderTextureに描画
            _camera.targetTexture = _renderTexture;
            _camera.Render();
            RenderTexture.active = _renderTexture;

            // Texture2Dの生成
            Texture2D texture2D = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.ARGB32, false, false);
            texture2D.ReadPixels(new Rect(0, 0, _renderTexture.width, _renderTexture.height), 0, 0);
            texture2D.Apply();

            _camera.targetTexture = null;
            RenderTexture.active = null;

            return texture2D;
        }
    }
}
