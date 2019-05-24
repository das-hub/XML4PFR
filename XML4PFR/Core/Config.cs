using System.IO;
using System.Xml.Serialization;
using das.Extensions.Logger;

namespace XML4PFR.Core
{
    [XmlRoot("configuration")]
    public class Config
    {
        private static string _file;        
        private static Config _config;

        public Config()
        {
            Providers = new[]{Provider.Default};
            LoggerSetting = LoggerSetting.Empty;
        }

        public static Config Load(string file)
        {
            if (_config != null) return _config;
                        
            _file = file;
            
            if (!File.Exists(_file)) return _config = new Config();

            XmlSerializer serializer = new XmlSerializer(typeof(Config));

            using (StreamReader reader = new StreamReader(_file))
            {
                _config = (Config)serializer.Deserialize(reader);
            }

            return _config;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));

            using (StreamWriter writer = File.CreateText(_file))
            {
                serializer.Serialize(writer, _config);
            }
        }

        [XmlElement("logger")]
        public LoggerSetting LoggerSetting { get; set; }

        [XmlArray("providers")]
        [XmlArrayItem("provider")]
        public Provider[] Providers { get; set; }
    }

    public class Provider
    {
        public static Provider Default
        {
            get
            {
                return new Provider
                {
                    Code = "000",
                    Caption = "000 - Без названия"
                };
            }
        }

        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("caption")]
        public string Caption { get; set; }
    }
}