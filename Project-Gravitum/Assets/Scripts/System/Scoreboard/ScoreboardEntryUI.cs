using TMPro;
using UnityEngine;
using System;
namespace Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {

            entryScoreText.text = FormatTime(scoreboardEntryData.time);
            //Debug.Log(scoreboardEntryData.time.ToString());
        }
        string FormatTime(float time)
        {
            int intTime = (int)time;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            float fraction = time * 1000;
            fraction = (fraction % 1000);
            string timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
            return timeText;
        }
    }

}