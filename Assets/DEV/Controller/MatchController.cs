using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MatchController : Controller
{
    #region Fields
    GameplayData gameplayData;
    [SerializeField] AttackController attackController;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject selectedMatch;
    [SerializeField] GameObject matchObj;
    [SerializeField] ObjectPool matchPool;
    [SerializeField] Transform teamAPos;
    [SerializeField] Transform teamBPos;
    private List<Match> matches = new List<Match>();
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        gameplayData = data;
    }
    #endregion

    #region Executes
    public void CreateRandomMatch(int count)
    {
        SetUI(false);
        for (int i = 0; i < count; i++)
        {
            Match match = matchPool.GetItem() as Match;
            match.SetMatchInfo(CONSTANTS.HEADER_TEXT, selectRandomScore(), selectRandomScore(), selectRandomTeamLogo(), selectRandomTeamLogo()); ;
            match.SetActive();
            matches.Add(match);
            match.GetComponent<Button>().onClick.AddListener(() => selectMatch(match));
        }
    }
    public void SetUI(bool isMatchSelected)
    {
        matchObj.SetActive(!isMatchSelected);
        selectedMatch.SetActive(isMatchSelected);
        UIManager.Instance.UpdateMatchAttackScreen(false);
        if (teamAPos.childCount != 0 || teamBPos.childCount != 0)
        {
            for (int i = 0; i < teamAPos.childCount; i++)
            {
                Destroy(teamAPos.GetChild(i).gameObject);
                Destroy(teamBPos.GetChild(i).gameObject);
            }
        }
    }
    private Sprite selectRandomTeamLogo()
    {
        int randomLogo = Random.Range(0, gameplayData.Logos.Count);
        Sprite selectedLogo = gameplayData.Logos[randomLogo];
        return selectedLogo;
    }
    private int selectRandomScore()
    {
        int score = Random.Range(0, 5);
        return score;
    }
    private void selectMatch(Match match)
    {
        foreach (Match m in matches)
        {
            if (m == match)
            {
                setRandomTime();
                SetUI(true);
                RectTransform teamATemp = Instantiate(match.TeamA, teamAPos) as RectTransform;
                RectTransform teamBTemp = Instantiate(match.TeamB, teamBPos) as RectTransform;

                resetRectTransformPosition(teamATemp);
                resetRectTransformPosition(teamBTemp);
                UIManager.Instance.UpdateMatchAttackScreen(true);
                attackController.CreateRandomMatches(Random.Range(1,6));
            }
        }
    }
    private void resetRectTransformPosition(RectTransform t)
    {
        t.anchorMin = new Vector2(0.5f, 0.5f);
        t.anchorMax = new Vector2(0.5f, 0.5f);

        t.anchoredPosition = Vector2.zero;
    }
    private void setRandomTime()
    {
        int tempHour = Random.Range(1, 24);
        int tempMin = Random.Range(1, 60);
        string hour = tempHour < 10 ? "0" + tempHour : tempHour.ToString();
        string minute = tempMin < 10 ? "0" + tempMin : tempMin.ToString();

        timerText.text = hour + ":" + minute;
    }
    #endregion
}
