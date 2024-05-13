using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

// public interface savePersistence
// {
//     void Save();
//     void load();
// }

public class saveFile : MonoBehaviour //, savePersistence
{
    public Text scoreText;
    public Transform lastCoords;
    public Transform player;
    int playerNum = PersistentParams.fileParameter;
    string fileName;
    string folderPath;
    string filePath;

    void Start()
    {
        folderPath = Application.persistentDataPath;
        if (playerNum < 10)
        {
            Save();
        }
        else
        {
            playerNum -= 10;
            load();
        }
    }
    void Update()
    {

    }

    public void Save()
    {

        fileName = "File" + playerNum + ".txt";
        filePath = Path.Combine(folderPath, fileName);


        // Check if the file exists
        if (File.Exists(filePath))
        {
            // If the file exists, update the values
            string[] lines = File.ReadAllLines(filePath);

            // Update the values
            lines[0] = PersistentParams.playerName;
            if (Int32.Parse(scoreText.text) > Int32.Parse(lines[1]))
            {
                Debug.Log("SCORE UPDATED");
                lines[1] = scoreText.text;
            }
            lines[2] = lastCoords.position.y.ToString();
            lines[3] = lastCoords.position.x.ToString();

            // Write the updated values back to the file
            File.WriteAllLines(filePath, lines);
        }
        else
        {
            // If the file doesn't exist, create a new one
            string[] lines = {
                    PersistentParams.playerName,
                    scoreText.text,
                    lastCoords.position.y.ToString(),
                    lastCoords.position.x.ToString()
                };

            // Write the lines to the file
            File.WriteAllLines(filePath, lines);
        }

        Debug.Log("Player data saved to: " + filePath);
    }

    public void load()
    {

        fileName = "File" + playerNum + ".txt";
        filePath = Path.Combine(folderPath, fileName);
        string[] lines = File.ReadAllLines(filePath);

        PersistentParams.playerName = lines[0];
        scoreText.text = lines[1];
        PersistentParams.highScore = Int32.Parse(lines[1]);
        Debug.Log(scoreText.text);


        //player.transform.position = new Vector3(float.Parse(lines[4]), float.Parse(lines[3]), 0);

    }


}
