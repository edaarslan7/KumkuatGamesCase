using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Match : SpawnableObject
{
	#region Fields
	[SerializeField] TextMeshProUGUI headerText;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] RectTransform teamA;
	[SerializeField] RectTransform teamB;
	[Header("Team Info")]
	[SerializeField] Image teamALogo;
	[SerializeField] Image teamBLogo;
	[SerializeField] TextMeshProUGUI teamAName;
	[SerializeField] TextMeshProUGUI teamBName;
	#endregion

	#region Getters
	public RectTransform TeamA => teamA;
	public RectTransform TeamB => teamB;
	#endregion

	#region Executes
	public void SetMatchInfo(string header, int teamAScore, int teamBScore, Sprite teamALogo, Sprite teamBLogo)
	{
		headerText.text = header;
		scoreText.text = teamAScore + "-" + teamBScore;
		this.teamALogo.sprite = teamALogo;
		this.teamBLogo.sprite = teamBLogo;
		teamAName.text = teamALogo.name;
		teamBName.text = teamBLogo.name;
	}
	#endregion
}
