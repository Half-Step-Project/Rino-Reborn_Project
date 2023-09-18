using System;
using Nino.Shared;

namespace Rino.Shared.Data
{
    [Serializable]
    public class RinoChart
    {
        public Metadata metadata;
        public class Metadata
        {
            public UncheckedList<BpmGroupData> bpmGroups;
        }
    }
    
    public class BpmGroupData
    {
        public float targetBeat;
        public float bpmValue;
        public float duration;
    }

    public class KeyFrameData
    {
        public float keyTime;
        public float keyValue;
    }
}
