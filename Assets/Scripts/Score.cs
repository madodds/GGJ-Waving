using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
	public int PlayerOneWaves;
    
	public int PlayerTwoWaves;

	public int MaxScore = 10;
	public int MaxFontSize = 60;
	public float FontSizeGrowthMod = 1.0f;
	public GUIText PlayerOneScoreLabel;
	public GUIText PlayerTwoScoreLabel;
	public GUIText GameOverLabel;
    public GUIText Help;
	public Animator explosionAnimator;

	private bool _gameEnded;
    private bool _enterDown;
    private bool _gameStart = true;
    private float _growthMod;
    private string _winningText;

    public JoshArm player1;
    public MattArm player2;

    // Use this for initialization
    void Start()
	{
		PlayerOneWaves = 0;
		PlayerTwoWaves = 0;
		_gameEnded = false;
        _growthMod = FontSizeGrowthMod;
        GameOverLabel.fontSize = 1;
        _winningText = "Player {0} Is\nSuper Nice!!!";
    }

	// Update is called once per frame
	void Update()
	{
        if(Input.anyKeyDown)
        {
            Help.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Return) && !_enterDown)
        {
            Start();
            player1.Restart();
            player2.Restart();
            _enterDown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Return) && _enterDown)
        {
            _enterDown = false;
        }
		if (_gameEnded)
		{
			if (GameOverLabel.fontSize < MaxFontSize)
			{
				// The font size grows quickly.
				FontSizeGrowthMod *= FontSizeGrowthMod;
				int increase = Mathf.RoundToInt(FontSizeGrowthMod);
				if (GameOverLabel.fontSize + increase > MaxFontSize)
				{
					GameOverLabel.fontSize = MaxFontSize;
				}
				else
				{
					GameOverLabel.fontSize += increase;
				}
			}
		}
		else
		{
			// Update the UI and check for WINNING.
			PlayerOneScoreLabel.text = PlayerOneWaves.ToString();
			PlayerTwoScoreLabel.text = PlayerTwoWaves.ToString();
			if (PlayerOneWaves - PlayerTwoWaves >= MaxScore)
			{
				GameOver('1');
			}
			else if (PlayerTwoWaves - PlayerOneWaves >= MaxScore)
			{
				GameOver('2');
			}
		}
	}

	private void GameOver(char player)
	{
		explosionAnimator.SetTrigger("explode");
		_gameEnded = true;
        GameOverLabel.gameObject.SetActive(true);
        GameOverLabel.text = string.Format(_winningText, player);
	}
}