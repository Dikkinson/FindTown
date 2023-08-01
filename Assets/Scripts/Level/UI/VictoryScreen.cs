
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : Window
{
    public GameObject greenStamp;
    public Text scoreText;
    public Button continueButton;
    public RewardBlockView rewardBlock;

    public override void SetIdleAnim()
    {
        base.SetIdleAnim();

        greenStamp.SetActive(true);
    }
}
