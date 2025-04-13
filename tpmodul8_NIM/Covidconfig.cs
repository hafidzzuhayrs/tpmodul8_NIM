using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;
namespace tpmodul8_NIM
{
    class Covidconfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private static string filePath = "covid_config.json";

        public static Covidconfig LoadConfig()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Covidconfig>(json);
            }
            else
            {
                var defaultConfig = new Covidconfig();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }
            SaveConfig(); // Simpan perubahan ke file
        }
    }
}
