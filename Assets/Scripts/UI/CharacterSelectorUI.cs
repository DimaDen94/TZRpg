using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _createButton;

    [SerializeField] private Canvas _canvas;

    public event Action OnPlayButtonClick;
    public event Action OnCreateButtonClick;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _createButton.onClick.AddListener(OnCreateClicked);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
        _createButton.onClick.RemoveListener(OnCreateClicked);
    }

    public void Init(Camera main) => _canvas.worldCamera = main;

    private void OnPlayClicked() => OnPlayButtonClick?.Invoke();

    private void OnCreateClicked() => OnCreateButtonClick?.Invoke();

}