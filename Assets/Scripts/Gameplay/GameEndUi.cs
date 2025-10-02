using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameEndUi : MonoBehaviour
    {
        [SerializeField] CanvasGroup   canvasGroup;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private Image bg;

        private void OnValidate()
        {
            if(canvasGroup == null)canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            restartButton.onClick.AddListener(OnClickRestartButton);
            quitButton.onClick.AddListener(OnClickQuitButton);
            RatingsManager.GameEnd += OnGameEnd;
            bg.raycastTarget = false;
            canvasGroup.alpha = 0;
        }

        private void OnDisable()
        {
            restartButton.onClick.RemoveListener(OnClickRestartButton);
            quitButton.onClick.RemoveListener(OnClickQuitButton);
            RatingsManager.GameEnd -= OnGameEnd;
        }

        private void OnGameEnd()
        {
            bg.raycastTarget = true;
            canvasGroup.DOFade(1, 0.5f);
        }

        private void OnClickQuitButton()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        private void OnClickRestartButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}