var sample = new Sample();
sample.PrintSampleData();
sample.PrintVariationSeries();
sample.PrintFrequency();
sample.PrintIntegralFrequency();

public class Sample
{

    #region Properties: Private

    List<int> _numsInSample = new List<int>();
    private readonly static int _numberInGroup = 1;

    #endregion

    #region Constructors: Public

    public Sample()
    {
        var random = new Random();
        for (int i = 0; i < _numberInGroup + 10; i++)
        {
            _numsInSample.Add(random.Next(_numberInGroup + 1)+1);
        }
    }

    #endregion

    #region Methods: Public

    public void PrintSampleData()
    {
        Console.WriteLine("Sample data:");
        _numsInSample.ForEach(n => Console.Write(n+"; "));
        Console.WriteLine();
    }

    public void PrintVariationSeries()
    {
        Console.WriteLine("Variation series:");
        _numsInSample.Sort();
        _numsInSample.ForEach(n => Console.Write(n + "; "));
        Console.WriteLine();
    }

    public void PrintFrequency()
    {
        Console.WriteLine("Frequency:");
        _numsInSample.GroupBy(n => n)
            .Select(group => new
            {
                Variant = group.Key,
                Frequency = group.Count()
            }).ToList().ForEach(f => Console.WriteLine(f));
    }

    public void PrintIntegralFrequency()
    {
        Console.WriteLine("Integral frequency:");
        var feqSum = 0;
        _numsInSample.GroupBy(n => n)
            .Select(group => new
            {
                Variant = group.Key,
                Frequency = (feqSum += group.Count())
            }).ToList().ForEach(f => Console.WriteLine(f));
    }

    #endregion

}
