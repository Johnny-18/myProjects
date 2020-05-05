using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace ExOneForCourse_Matrix
{
    public class DataBaseService
    {
        private string filePath = ConfigurationManager.AppSettings.Get("CurrentFolder") 
                                + ConfigurationManager.AppSettings.Get("FileName");
        public DataBaseService() { }
        public void JsonSerialize<T>(List<Matrix<T>> data)
        {
            if (data == null)
                throw new System.ArgumentNullException("ArgumentNullInSerializationException!");

            string output = JsonConvert.SerializeObject(data);
            using (FileStream fstream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(output);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
        public List<Matrix<T>> JsonDeserialize<T>()
        {
            using (FileStream fstream = File.OpenRead(filePath))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                List<Matrix<T>> listMatrix = JsonConvert.DeserializeObject<List<Matrix<T>>>(textFromFile);
                return listMatrix;
            }
        }
    }
}
