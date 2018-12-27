namespace bees_management_system
{
    public class Bee : IStingPatrol
    {
        public const double HoneyUnitsConsumePerMg = .25;

        public double WeightMg { get; private set; }

        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        virtual public double HoneyConsumptionRate()
        {
            return WeightMg * HoneyUnitsConsumePerMg;
        }
    }
}