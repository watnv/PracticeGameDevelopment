using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Practice5
{
    public class TermsManager : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollView;
        [SerializeField] private Button _agreeButton;
        [SerializeField] private Button _backButton;

        // 初期処理
        private void Start()
        {
            _agreeButton.onClick.AddListener(AgreeButtonPushed);
            _backButton.onClick.AddListener(BackButtonPushed);
            _scrollView.onValueChanged.AddListener(TermsScrollValueChanged);

            TermsActive(true);
        }

        // スクロール位置が変わった場合の処理
        private void TermsScrollValueChanged(Vector2 val)
        {
            if (val.y == 0f)
            {
                _agreeButton.gameObject.SetActive(true);
            }
        }

        // 『同意する』ボタン押下時の処理
        private void AgreeButtonPushed()
        {
            TermsActive(false);
        }

        // 『戻る』ボタン押下時の処理
        private void BackButtonPushed()
        {
            _scrollView.verticalScrollbar.value = 1.0f;
            _scrollView.verticalNormalizedPosition = 1.0f;
            TermsActive(true);
        }

        // オブジェクトの表示/非表示切り替え処理
        private void TermsActive(bool active)
        {
            _scrollView.gameObject.SetActive(active);
            _agreeButton.gameObject.SetActive(false);
            _backButton.gameObject.SetActive(!active);
        }
    }
}
