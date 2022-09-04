using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MysticVoice
{
    public interface IDataPersistence
    {
        void LoadData(GameData data);
        void SaveData(ref GameData data);
    }
}
