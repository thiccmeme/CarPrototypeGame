using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScoreText;
    [SerializeField] private TMP_Text _playerHealthText;
    private Player _player; 
    private float _timer;
    public int _score = 0;
    private int _currentHealth;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
        _playerScoreText.text = _score.ToString(); //start game with 0 score
        _playerHealthText.text = _player.pHealth.ToString();
        _currentHealth = _player.pHealth;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 1f)
        {
            _score += 1;

            //Update the HUD text when the score change
            _playerScoreText.text = _score.ToString();

            _timer = 0; //Reset timer to 0.
        }

        if (_player.pHealth <= _currentHealth)
        {
            _currentHealth = _player.pHealth;

            //Update the HUD text when the score change
            _playerHealthText.text = _currentHealth.ToString();
        }
    }
}
