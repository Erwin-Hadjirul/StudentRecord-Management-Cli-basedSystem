namespace StudentRecordManagement.Cli;

internal class TestStudent
{
    // Repositories
    static List<BSCS> BSCSs = new List<BSCS>();
    static List<BSIT> BSITs = new List<BSIT>();

    static void DisplayMainMenu()
    {
        Console.WriteLine("Student Record Management");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. View");
        Console.WriteLine("3. Search");
        Console.WriteLine("4. Exit");
    }

    static int GetUserChoiceFromMainMenu()
    {
        int value;

        while (true)
        {
            Console.Write("Choose: ");
            string choiceAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choiceAsString))
                continue;

            if (!int.TryParse(choiceAsString, out value))
                continue;

            if (value == 0 || value > 4) continue;

            break;
        }
        return value;
    }

    static void DisplayAddSection()
    {
        Console.WriteLine("Add Student");
        Console.WriteLine("1. BSCS");
        Console.WriteLine("2. BSIT");
        Console.WriteLine("3. Back to Main Menu");
    }

    static int GetUserChoiceFromAddSection()
    {
        int value;

        while (true)
        {
            Console.Write("Choose: ");
            string choiceAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choiceAsString))
                continue;

            if (!int.TryParse(choiceAsString, out value))
                continue;

            if (value == 0 || value > 3) continue;

            break;
        }
        return value;
    }

    static BSCS PostBSCSStudent()
    {
        string name;
        int age;
        int yearLvl;

        while (true)
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) continue;
            if (new BSCS(name, 0, 0).Name != name) continue;

            break;
        }

        while (true)
        {
            Console.Write("Enter Age: ");
            string ageAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ageAsString)) continue;
            if (!int.TryParse(ageAsString, out age))
                continue;
            if (new BSCS("", age, 0).Age != age) continue;

            break;
        }

        while (true)
        {
            Console.Write("Enter Year Level: ");
            string yearLevelAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(yearLevelAsString)) continue;
            if (!int.TryParse(yearLevelAsString, out yearLvl))
                continue;
            if (new BSCS("", 0, yearLvl).YearLevel != yearLvl) continue;

            break;
        }

        return new BSCS(name, age, yearLvl);
    }

    static BSIT PostBSITStudent()
    {
        string name;
        string specialization;
        double allowance;

        while (true)
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) continue;
            if (new BSIT(name, "", 0d).Name != name) continue;

            break;
        }

        while (true)
        {
            Console.Write("Enter Specialization: ");
            specialization = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(specialization)) continue;
            if (new BSIT("", specialization, 0d).Specialization != specialization)
                continue;

            break;
        }

        while (true)
        {
            Console.Write("Enter Allowance: ");
            string allowanceAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(allowanceAsString)) continue;
            if (!double.TryParse(allowanceAsString, out allowance))
                continue;
            if (new BSIT("", "", allowance).Allowance != allowance) continue;

            break;
        }

        return new BSIT(name, specialization, allowance);
    }

    static void AddStudentToARepository<T>(T student)
    {
        if (student is BSCS bscs)
        {
            BSCSs.Add(bscs);
        }
        else if (student is BSIT bsit)
        {
            BSITs.Add(bsit);
        }
    }

    static void DisplayViewSection()
    {
        Console.WriteLine("View Student");
        Console.WriteLine("1. BSCS");
        Console.WriteLine("2. BSIT");
        Console.WriteLine("3. Back to Main Menu");
    }

    static int GetUserChoiceFromViewSection()
    {
        int value;

        while (true)
        {
            Console.Write("Choose: ");
            string choiceAsString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choiceAsString))
                continue;

            if (!int.TryParse(choiceAsString, out value))
                continue;

            if (value == 0 || value > 3) continue;

            break;
        }

        return value;
    }

    static IList<T>? GetStudents<T>()
    {
        if (typeof(T) == typeof(BSCS))
        {
            return (IList<T>)BSCSs;
        }
        else if (typeof(T) == typeof(BSIT))
        {
            return (IList<T>)BSITs;
        }

        return null;
    }

    static string DisplayAndInputSearchSection()
    {
        string input;

        while (true)
        {
            Console.Write("Search(Name): ");
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) continue;
            if (new BSCS(input, 0, 0).Name != input) continue;
            if (new BSIT(input, "", 0d).Name != input) continue;

            break;
        }

        return input;
    }

    static bool DoesStudentExists(string studentName)
    {
        var bscsStudent = BSCSs.FirstOrDefault(s =>
            s.Name.ToLower() == studentName.ToLower());
        var bsitStudent = BSITs.FirstOrDefault(s =>
            s.Name.ToLower() == studentName.ToLower());

        if (bscsStudent == null && bsitStudent == null)
            return false;

        return true;
    }

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMainMenu();
            int userChoiceFromMainMenu = GetUserChoiceFromMainMenu();

            if (userChoiceFromMainMenu == 1) // Add
            {
                while (true)
                {
                    DisplayAddSection();
                    int userChoiceFromAddSection = GetUserChoiceFromAddSection();

                    if (userChoiceFromAddSection == 1) // BSCS
                    {
                        BSCS newStudent = PostBSCSStudent();
                        AddStudentToARepository<BSCS>(newStudent);
                    }
                    else if (userChoiceFromAddSection == 2) // BSIT
                    {
                        BSIT newStudent = PostBSITStudent();
                        AddStudentToARepository<BSIT>(newStudent);
                    }
                    else if (userChoiceFromAddSection == 3) // Back to Main Menu
                    { break; }
                }
            }
            else if (userChoiceFromMainMenu == 2) // View
            {
                while (true)
                {
                    DisplayViewSection();
                    int userChoiceFromViewSection = GetUserChoiceFromViewSection();

                    if (userChoiceFromViewSection == 1) // BSCS
                    {
                        var listOfStudents = GetStudents<BSCS>();

                        if (listOfStudents == null) Console.WriteLine();

                        foreach (var student in listOfStudents)
                        {
                            Console.WriteLine($"Name: {student.Name}");
                            Console.WriteLine($"Age: {student.Age}");
                            Console.WriteLine($"Year Level: {student.YearLevel}");
                        }
                    }
                    else if (userChoiceFromViewSection == 2) // BSIT
                    {
                        var listOfStudents = GetStudents<BSIT>();

                        if (listOfStudents == null) Console.WriteLine();

                        foreach (var student in listOfStudents)
                        {
                            Console.WriteLine($"Name: {student.Name}");
                            Console.WriteLine($"Specialization: {student.Specialization}");
                            Console.WriteLine($"Allowance: {student.Allowance:N2}");
                        }
                    }
                    else if (userChoiceFromViewSection == 3) // Back to Main Menu
                    { break; }
                }
            }
            else if (userChoiceFromMainMenu == 3) // Search
            {
                while (true)
                {
                    string toSearch = DisplayAndInputSearchSection();

                    if (DoesStudentExists(toSearch))
                    { Console.WriteLine("Record Found!!!!"); break; }
                    else
                    { Console.WriteLine("Record Not Found!!!!"); break; }
                }
            }
            else if (userChoiceFromMainMenu == 4) // Exit
            { break; }
        }

        Console.WriteLine("Program Terminated!!!!");
    }
}