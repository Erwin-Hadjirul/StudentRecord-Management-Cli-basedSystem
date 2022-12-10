namespace StudentRecordManagement.Cli;

public class BSIT
{
    private string _name;
    private string _specialization;
    private double _allowance;

    public BSIT(string name, string specialization, double allowance)
    {
        Name = name;
        Specialization = specialization;
        Allowance = allowance;
    }

    public string Name
    {
        get { return _name; }
        private set
        {
            foreach (char letter in value)
            {
                if (!char.IsLetter(letter))
                {
                    _name = "";
                    return;
                }
            }

            _name = value;
        }
    }

    public string Specialization
    {
        get { return _specialization; }
        private set
        {
            string onlyAccepts_Pattern = "(AGD|DA|WMA|SMBA)";
            Regex regex = new (onlyAccepts_Pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant,
                TimeSpan.FromSeconds(2));
            Match match = regex.Match(value);

            if (!match.Success)
            {
                _specialization = "";
                return;
            }

            _specialization = value;
        }
    }

    public double Allowance
    {
        get { return _allowance;}
        private set
        {
            if (value < 250d || value > 1000d)
            {
                _allowance = -1d;
                return;
            }

            _allowance = value;
        }
    }
}
