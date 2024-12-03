using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private DamageablePerson _person;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private bool _alphaSwitchEnabled = true;

    private CanvasGroup _canvasGroup;
    private float _alphaTurnOffDelay = 1f;
    private WaitForSeconds _waitAlphaTurnOffDelay;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _waitAlphaTurnOffDelay = new WaitForSeconds(_alphaTurnOffDelay);
    }

    private void Start()
    {
        DisplayHealth(_person.Health, _person.MaxHealth);
    }

    private void OnEnable()
    {
        _person.HealthChanged += DisplayHealth;
    }

    private void OnDisable()
    {
        _person.HealthChanged += DisplayHealth;
    }

    private void DisplayHealth(int currentHealth, int maxHealth)
    {
        _healthBar.DisplayHealth(currentHealth, maxHealth);

        if (_alphaSwitchEnabled)
        {
            if (_person.IsDead)
                StartCoroutine(TurnOffAlphaWithDelay());
            else
                _canvasGroup.alpha = 1;
        }
    }

    private IEnumerator TurnOffAlphaWithDelay()
    {        
        yield return _waitAlphaTurnOffDelay;

        _canvasGroup.alpha = 0;
    }
}
