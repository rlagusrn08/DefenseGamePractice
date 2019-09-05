using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class StartManager : MonoBehaviour
{
    public void GameStart()
    { 
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowRewardedAd();
        Screen.SetResolution(1920, 1200, true);
        Advertisement.Initialize("3279749", false);
    }

    private void ShowRewardedAd()
    {
        if(Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("사용자가 광고를 성공적으로 보았음");
                break;
            case ShowResult.Skipped:
                Debug.Log("사용자가 광고를 스킵함");
                break;
            case ShowResult.Failed:
                Debug.Log("광고에서 오류 발생");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
