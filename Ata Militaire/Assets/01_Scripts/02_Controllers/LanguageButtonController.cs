using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageButtonController : MonoBehaviour
{
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Sprite _frenchSprite;
    [SerializeField] private Sprite _englishSprite;

    private UnityEvent<bool> _languageChangedEvent = new UnityEvent<bool>(); // true when english
    public UnityEvent<bool> LanguageChangedEvent => _languageChangedEvent;

    private bool _english = true;
    public bool English => _english;

    private void Awake()
    {
        StartCoroutine(SetLocale(0));
    }

    public void SwitchLanguage()
    {
        _english = !_english;
        StartCoroutine(SetLocale(_english ? 0 : 1));
    }

    IEnumerator SetLocale(int localeId)
    {
        yield return LocalizationSettings.InitializationOperation; // wait for localization to be loaded
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        _languageChangedEvent.Invoke(localeId == 0);

        _buttonImage.sprite = _english ? _englishSprite : _frenchSprite;
    }
}
