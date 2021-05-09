using System.IO;
using UnityEngine;

namespace Scoreboards
{
    // Start is called before the first frame update
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] private float testEntryTime = 0f;

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";
        public Canvas visible;
        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            //Debug.Log(savedScores.ToString());

            UpdateUI(savedScores);
            SaveScores(savedScores);

        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            AddEntry(new ScoreboardEntryData()
            {
                time = testEntryTime
            });
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Check if the score is high enough to be added.
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (scoreboardEntryData.time < savedScores.highscores[i].time)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            //Check if the score can be added to the end of the list.
            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Remove any scores past the limit.
            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }
            SaveScores(savedScores);
            UpdateUI(savedScores);


        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            //Debug.Log(savedScores.highscores[0].time);
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }

        }

        private ScoreboardSaveData GetSavedScores()
        {

            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();

            }
            
            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }

       
    }
}
