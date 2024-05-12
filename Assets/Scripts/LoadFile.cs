using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class loadFile : MonoBehaviour
{
    //public GameObject button;

    public Text[] buttonsText;

    public Text inputField;

    public int fileCount;

    public string[] fileIndexes;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log(Application.persistentDataPath);
        string folderPath = Application.persistentDataPath;
        string fileName;
        string filePath;

        for (int i = 0; i < fileCount; i++)
        {

            fileName = "File" + fileIndexes[i] + ".txt";
            filePath = Path.Combine(folderPath, fileName);
            //Debug.Log(fileName);
            if (File.Exists(filePath))
            {
                // Debug.Log("File Found");
                string[] lines = File.ReadAllLines(filePath);
                buttonsText[i * 3].text = lines[0];
                buttonsText[i * 3 + 1].text = lines[1];
                buttonsText[i * 3 + 2].text = lines[2];

            }
            else
            {
                //Debug.Log("No file available");
                buttonsText[i * 3].text = "No File Available";
                buttonsText[i * 3 + 1].text = "Score: <>";
                buttonsText[i * 3 + 2].text = "Time: <>";
            }


        }
    }

    public void setFileNum(int fileNum)
    {
        string folderPath = Application.persistentDataPath;
        string fileName;

        if (fileNum > 10)
        {
            fileName = "File" + (fileNum - 10) + ".txt";
        }
        else
            fileName = "File" + fileNum + ".txt";

        string filePath = Path.Combine(folderPath, fileName);





        if (File.Exists(filePath) && fileNum > 10)
        {
            PersistentParams.fileParameter = fileNum;
            PersistentParams.isLoading = true;
            SceneManager.LoadScene("Game");
        }
        else if (fileNum < 10)
        {
            PersistentParams.isLoading = false;
            PersistentParams.playerName = inputField.text;
            UnityEngine.Debug.Log(PersistentParams.playerName);
            SceneManager.LoadScene("Game");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }


}
