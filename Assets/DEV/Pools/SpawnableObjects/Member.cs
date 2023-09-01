using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Member : SpawnableObject
{
    #region Fields
    [SerializeField] Image photo;
    [SerializeField] Image flag;
    [SerializeField] TextMeshProUGUI memberName;
    [SerializeField] TextMeshProUGUI starText;
    [SerializeField] TextMeshProUGUI activity;
    [SerializeField] TextMeshProUGUI rank;
    private int star;
    #endregion

    #region Getter
    public int Star => star;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        base.Initialize(data);
        star = Random.Range(1, 25);
    }
    #endregion

    #region Execute
    public void SetMemberInfo(Sprite photo, Sprite flag, string memberName, string activity, int rank)
    {
        this.photo.sprite = photo;
        this.flag.sprite = flag;
        this.memberName.text = memberName;
        this.starText.text = star.ToString();
        this.activity.text = activity + "hour ago.";
        this.rank.text = (rank + 1).ToString();
    }
    #endregion
}
