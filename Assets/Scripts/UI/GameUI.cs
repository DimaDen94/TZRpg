using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Canvas _canvas;

    public event Action OnBackButtonClick;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(OnBackClicked);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(OnBackClicked);
    }

    public void Init(Camera main) => _canvas.worldCamera = main;

    private void OnBackClicked() => OnBackButtonClick?.Invoke();


}
