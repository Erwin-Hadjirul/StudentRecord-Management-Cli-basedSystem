namespace StudentRecordManagement.Cli;

public class BSCS
{
    private string _name;
    private int _age;
    private int _yearLevel;

    public BSCS(string name, int age, int yearLevel)
    {
        Name = name;
        Age = age;
        YearLevel = yearLevel;
    }

    public string Name
    {
        get { return _name; }
        private set
        {
            foreach (char letter in value)
            {
                if (!(char.IsLetter(letter) || char.IsWhiteSpace(letter)))
                {
                    _name = "";
                    return;
                }
            }

            _name = value;
        }
    }

    public int Age
    {
        get { return _age; }
        private set
        {
            if (value < 16 || value > 35)
            {
                _age = -1;
                return;
            }

            _age = value;
        }
    }

    public int YearLevel
    {
        get { return _yearLevel; }
        private set
        {
            if (value < 1 || value > 4)
            {
                _yearLevel = -1;
                return;
            }

            _yearLevel = value;
        }
    }
}
