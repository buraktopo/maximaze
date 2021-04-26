using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player1");

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            PlayerData data = new PlayerData(player);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player1");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
			FileStream stream = new FileStream(path, FileMode.Create);
            PlayerData data = new PlayerData();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, data);
            stream.Close();
			return null;
		}
    }
}