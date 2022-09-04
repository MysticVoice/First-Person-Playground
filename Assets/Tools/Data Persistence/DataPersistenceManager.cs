using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace MysticVoice
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;
        const string SAVE_FOLDER = "Saves";
        public string saveName;

        private GameData gameData;
        private List<IDataPersistence> dataPersistenceObjects;
        private FileDataHandler dataHandler;
        public static DataPersistenceManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("More than one Data Persistence Manager");
            }
            instance = this;
        }

        private void Start()
        {
            string savePath = Path.Combine(Application.persistentDataPath, SAVE_FOLDER, saveName);
            dataHandler = new FileDataHandler(savePath, fileName);
            this.dataPersistenceObjects = FindAllDatapersistenceObjects();
            LoadGame();
        }

        private void NewGame()
        {
            this.gameData = new GameData();
        }

        public void LoadGame()
        {
            //TODO load saved data using data handler
            this.gameData = dataHandler.Load();
            //if no data initialize
            if (this.gameData == null)
            {
                Debug.Log("No data was found. Initializing data to defaults.");
                NewGame();
            }
            //TODO push loaded data to scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
        }

        public void SaveGame()
        {
            // pass data to scripts so they can update it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref gameData);
            }
            // save data to a file using data handler
            dataHandler.Save(gameData);
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDatapersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}
