namespace Lab_1.Classes
{
    class ImpactModel
    {
        public ImpactModel(double rangeMin, double rangeMax, int intensity, double perceptionCofficient)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            Intensity = intensity;
            PerceptionCofficient = perceptionCofficient;
        }

        public double RangeMin { get; }
        public double RangeMax { get; }
        public int Intensity { get; }
        public double PerceptionCofficient { get; }
    }
}
