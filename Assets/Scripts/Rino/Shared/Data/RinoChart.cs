using System;
using Newtonsoft.Json;
using Nino.Shared;
using Rino.Shared.Interface;
using Rino.Shared.Utils;
using UnityEngine;

namespace Rino.Shared.Data
{
    [Serializable]
    public class RinoChart
    {
        public MetaData metaData;
        public LineData lineData;

        public class MetaData
        {
            public string composer, illustrator, charter;
            public string harderName;
            public string displayDiff;
            public int realDiff;
            public UncheckedList<BpmGroupData> bpmGroups = new();
        }

        public class BpmGroupData
        {
            public float targetBeat;
            public float bpmValue;
            public float duration;
        }

        public class LineData
        {

        }

        public class NoteData
        {

        }
    }

    public class KeyFrameData
    {
        public float keyTime;
        public float keyValue;
        public EaseUtility.Ease easingType;
    }

    public class KeyFrameColor
    {
        public float keyTime;
        [JsonConverter(typeof(ColorConverter))] public Color startValue, endValue;
        public EaseUtility.Ease easingType;
    }
    
    public class ColorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null) return null;
            var str = reader.Value.ToString().FastSplit(",");
            return new Color(float.Parse(str[0]), float.Parse(str[1]), float.Parse(str[2]), float.Parse(str[3]));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                var c = (Color)value;
                serializer.Serialize(writer, c.ToString().Replace("RGBA(", "").Replace(")", "").Replace(" ", ""));
            }
            else serializer.Serialize(writer, "0,0,0,0");
        }
    }
}
