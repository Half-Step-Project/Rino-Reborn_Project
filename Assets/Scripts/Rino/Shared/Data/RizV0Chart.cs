using System;
using Newtonsoft.Json;
using Rino.Shared.Interface;
using UnityEngine;

namespace Rino.Shared.Data
{
    [Serializable]
    public class RizV0Chart : IChartConvertable
    {
        public int fileVersion;
        public string songsName;
        public Theme[] themes;
        public ChallengeTime[] challengeTimes;
        [JsonProperty("bPM")] public float baseBpm;
        public ValueSet[] bpmShifts;
        public float offset;
        public Line[] lines;
        public CanvasMove[] canvasMoves;
        public CameraMove cameraMove;

        [Serializable]
        public class Theme
        {
            public ColorData[] colorsList;
        }

        [Serializable]
        public class ColorData
        {
            public int r, g, b, a; // 0-255

            public static explicit operator Color(ColorData data)
            {
                return new Color(data.r / 255f, data.g / 255f, data.b / 255f, data.a / 255f);
            }
        }

        [Serializable]
        public class ChallengeTime
        {
            public float checkPoint, start, end, transTime;
        }

        [Serializable]
        public class ValueSet : IComparable<ValueSet>
        {
            public float time, value, easeType; //, floorPosition;

            public int CompareTo(ValueSet other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return time.CompareTo(other.time);
            }
        }

        [Serializable]
        public class ValueSetColor : IComparable<ValueSetColor>
        {
            public ColorData startColor, endColor;
            public float time;

            public int CompareTo(ValueSetColor other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return time.CompareTo(other.time);
            }
        }

        [Serializable]
        public class Line
        {
            public LinePoint[] linePoints;
            public Note[] notes;
            public ValueSetColor[] judgeRingColor;
            public ValueSetColor[] lineColor;
        }

        [Serializable]
        public class LinePoint
        {
            public float time, xPosition, floorPosition;
            public ColorData color;
            public int easeType, canvasIndex;
        }

        [Serializable]
        public class Note
        {
            public int type;
            public float time, floorPosition;
            [JsonProperty("otherInformations")] public float[] otherInformation;
        }

        [Serializable]
        public class CanvasMove
        {
            public int index;
            public ValueSet[] xPositionKeyPoints, speedKeyPoints;
        }

        [Serializable]
        public class CameraMove
        {
            public ValueSet[] xPositionKeyPoints, scaleKeyPoints;
        }

        // TODO: Convert Chart
        public RinoChart ConvertToRino()
        {
            return null;
        }
    }
}