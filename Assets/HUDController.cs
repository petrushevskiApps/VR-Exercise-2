using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

    public float batteryTimeRatio;
    public float batteryLifePercentages;       // Percentages
    private float remainingTimeSeconds;        // In seconds

    public Text batteryLifeText; 
    public Text remainingTimeText;

	// Use this for initialization
	void Start ()
    {
        remainingTimeSeconds = batteryLifePercentages * batteryTimeRatio;
        DrawBatteryLife();
        DrawRemainingTime();
        StartCoroutine(DrainBattery());
	}
	
	IEnumerator DrainBattery()
    {
        float elapsedTime = 0;
        float elapsedBatteryTime = 0;

        while (remainingTimeSeconds > 0)
        {
            elapsedTime += Time.deltaTime;
            elapsedBatteryTime += Time.deltaTime;

            if (Mathf.Clamp(elapsedTime, 0, 1) == 1)
            {
                remainingTimeSeconds --;
                DrawRemainingTime();
                elapsedTime = 0;
            }

            if (Mathf.Clamp(elapsedBatteryTime, 0, batteryTimeRatio) == batteryTimeRatio)
            {
                batteryLifePercentages--;
                DrawBatteryLife();
                elapsedBatteryTime = 0;
            }

            yield return null;
        }
    }
 
    private void DrawBatteryLife()
    {
        if(batteryLifePercentages < 30)
        {
            batteryLifeText.color = Color.red;
        }
        batteryLifeText.text = batteryLifePercentages.ToString() + "%";

    }
    private void DrawRemainingTime()
    {
        int minutes = Mathf.FloorToInt(remainingTimeSeconds / 60);
        int seconds = Mathf.FloorToInt(remainingTimeSeconds - (minutes * 60));

        string minutesText = FormatText(minutes);
        string secondsText = FormatText(seconds);

        remainingTimeText.text = minutesText + ":" + secondsText;
    }
    private string FormatText(float n)
    {
        return n < 10 ? "0" + n : n.ToString();
    }
}
