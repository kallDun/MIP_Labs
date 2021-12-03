using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Classes
{
    class InformationImpactProcess
    {
        private States state = States.Waiting;
        public States State => state;

        private double memory;
        public double Memory => memory;

        private DateTime date;
        public DateTime Date => date;

        private Dictionary<ImpactModel, int> impact_models;
        public InformationImpactProcess(DateTime date, params ImpactModel[] impacts)
        {
            this.date = date;
            impact_models = impacts.ToDictionary(x => x, x => 0);
        }

        public void ChangeDay()
        {
            for (int i = 0; i < impact_models.Count; i++)
            {
                MakeImpact(impact_models.ElementAt(i).Key);
                CheckMemoryToChangeState();
            }
            date = date.AddDays(1);
        }

        Random random = new();
        private void MakeImpact(ImpactModel model)
        {
            if (model.Intensity - impact_models[model] == 0) return;

            var remaining_days = DateTime.DaysInMonth(date.Year, date.Month);
            var chance = remaining_days / (model.Intensity - impact_models[model]);
            if (random.Next(0, chance) == 1)
            {
                impact_models[model]++;
                if (random.NextDouble() < model.PerceptionCofficient)
                {
                    var impact = random.NextDouble() * (model.RangeMax - model.RangeMin) + model.RangeMin;
                    memory += impact;
                }
            }

        }

        private void CheckMemoryToChangeState()
        {
            foreach (var threshold in InformationDictionary.Thresholds[state].Reverse())
            {
                if (threshold.Value > 0 && threshold.Value <= memory)
                {
                    state = threshold.Key;
                    memory = 0;
                    break;
                }
            }
        }
    }
}
