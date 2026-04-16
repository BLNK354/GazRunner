using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiTimer : MonoBehaviour
{
    public Text timerText; // Assign a UI Text element in the Inspector

    private float[] timerDurations = { 180f, 120f, 60f }; // 3 min, 2 min, 1 min
    private int currentTimerIndex = 0;

    void Start()
    {
        StartCoroutine(RunTimers());
    }

    IEnumerator RunTimers()
    {
        while (currentTimerIndex < timerDurations.Length)
        {
            float timeRemaining = timerDurations[currentTimerIndex];

            while (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
                yield return null;
            }

            Debug.Log("Timer " + (currentTimerIndex + 1) + " finished!");
            currentTimerIndex++;
        }

        Debug.Log("All timers finished!");
    }

    void UpdateTimerDisplay(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
