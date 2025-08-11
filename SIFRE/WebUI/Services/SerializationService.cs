using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace WebUI.Services
{
    public class SerializationService : ISerializationService
    {
        private static readonly JsonSerializerOptions DefaultJsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public string SerializeToJson<T>(T value)
        {
            return JsonSerializer.Serialize(value, DefaultJsonOptions);
        }

        public T? DeserializeFromJson<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultJsonOptions);
        }

        public string SerializeToXml<T>(T value)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, value);
            return stringWriter.ToString();
        }

        public T? DeserializeFromXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var stringReader = new StringReader(xml);
            return (T?)serializer.Deserialize(stringReader);
        }

        public string DetectFormat(string contentOrFileName)
        {
            if (string.IsNullOrWhiteSpace(contentOrFileName)) return "unknown";

            // File name hint
            var lower = contentOrFileName.Trim().ToLowerInvariant();
            if (lower.EndsWith(".json")) return "json";
            if (lower.EndsWith(".xml")) return "xml";

            // Content hint
            var trimmed = contentOrFileName.TrimStart();
            if (trimmed.StartsWith("{")) return "json";
            if (trimmed.StartsWith("<")) return "xml";

            return "unknown";
        }
    }
}


