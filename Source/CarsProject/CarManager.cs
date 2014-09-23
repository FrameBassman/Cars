namespace CarsProject
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// 
    /// </summary>
    public static class CarManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Save(Car savedCar)
        {
            Stream stream = File.Open(@"settings.txt", FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, savedCar);
            stream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Car Load()
        {
            Car loadingCar;
            Stream stream = File.Open(@"settings.txt", FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            loadingCar = (Car)bFormatter.Deserialize(stream);
            stream.Close();
            return loadingCar;
        }
    }
}
