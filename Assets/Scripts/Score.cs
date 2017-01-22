using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	[HideInInspector]
	public int PlayerOneWaves;

	[HideInInspector]
	public int PlayerTwoWaves;

	public int MaxScore = 10;
	public int MaxFontSize = 60;
	public float FontSizeGrowthMod = 1.2f;
	public GUIText PlayerOneScoreLabel;
	public GUIText PlayerTwoScoreLabel;
	public GUIText GameOverLabel;
	public Animator explosionAnimator;

	private bool _gameEnded;

	// Use this for initialization
	void Start()
	{
		PlayerOneWaves = 0;
		PlayerTwoWaves = 0;
		_gameEnded = false;
	}

	// Update is called once per frame
	void Update()
	{
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
		explosionAnimator.SetTrigger("explosion");
		_gameEnded = true;
		GameOverLabel.enabled = true;
		GameOverLabel.text = GameOverLabel.text.Replace('~', player);
	}
}