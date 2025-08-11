using System;
using System.IO;

namespace WebUI.Services
{
    public interface ISerializationService
    {
        string SerializeToJson<T>(T value);
        T? DeserializeFromJson<T>(string json);

        string SerializeToXml<T>(T value);
        T? DeserializeFromXml<T>(string xml);

        string DetectFormat(string contentOrFileName);
    }
}


