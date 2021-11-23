using System.Collections.Generic;
using static Lab_1.Classes.States;

namespace Lab_1.Classes
{
    static class InformationDictionary
    {
        public static Dictionary<States, Dictionary<States, double>> Thresholds => new()
        {
            {
                Waiting,
                new()
                {
                    { Waiting, 0 },
                    { LowReadiness, 0.3 },
                    { MediumReadiness, 0.5 },
                    { HighReadiness, 0.8 },
                    { Completion, -1 }
                }
            },
            {
                LowReadiness,
                new()
                {
                    { Waiting, -1 },
                    { LowReadiness, 0 },
                    { MediumReadiness, 0.2 },
                    { HighReadiness, 0.5 },
                    { Completion, 0.7 }
                }
            },
            {
                MediumReadiness,
                new()
                {
                    { Waiting, -1 },
                    { LowReadiness, -1 },
                    { MediumReadiness, 0 },
                    { HighReadiness, 0.4 },
                    { Completion, 0.6 }
                }
            },
            {
                HighReadiness,
                new()
                {
                    { Waiting, -1 },
                    { LowReadiness, -1 },
                    { MediumReadiness, -1 },
                    { HighReadiness, 0 },
                    { Completion, 0.1 }
                }
            },
            {
                Completion,
                new()
                {
                    { Waiting, -1 },
                    { LowReadiness, -1 },
                    { MediumReadiness, -1 },
                    { HighReadiness, -1 },
                    { Completion, 0 }
                }
            }
        };
 
    }
}
