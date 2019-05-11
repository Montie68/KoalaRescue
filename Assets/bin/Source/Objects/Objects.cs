using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace DBRObjects
{
    public static class InGameCurrency
    {
        public static string DataPath = Application.persistentDataPath + "/IGC.bin";

        public static void SaveCurrency(int Amount)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(DataPath, FileMode.Create);

            formatter.Serialize(stream, Amount);
            stream.Close();

        }

        public static int LoadCurrency()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(DataPath, FileMode.Open);
            if (!File.Exists(DataPath)) SaveCurrency(0);

            int Amount = (int)formatter.Deserialize(stream);
            stream.Close();

            return Amount;
        }
    }

}
