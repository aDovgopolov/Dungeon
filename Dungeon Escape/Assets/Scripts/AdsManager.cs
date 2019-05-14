using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
	public void Awake()
	{
		//player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	public void ShowRewardedAdd()
	{
		Debug.Log("Showing rewarded add!");

		//rewardedVideo
		if(Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions
			{
				resultCallback = HandleShowResult
			};
			Advertisement.Show("rewardedVideo", options);
		}
	}

	void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("Finished");
				GameManager.Instance.Player.AddGems(100);
				//UIManager.Instance.UpdateGemCount(player.diamonds);
				UIManager.Instance.OpenShop(GameManager.Instance.Player.diamonds);
				break;
			case ShowResult.Failed:
				Debug.Log("Failed");
				break;
			case ShowResult.Skipped:
				Debug.Log("Skipped");
				break;
		}
	}

}
