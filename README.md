# ![icon](favicon.ico) Student Record Management (CLI-based System)

![year](https://img.shields.io/badge/year-2022-blue)

A Simple System CLI-based where you can record the student information into it. It is not associated with database hence the data
will be gone when it is not running.

---

## Software Description

This is a Console App or CLI-based System (Command-line Interface -based System) developed using C# Programming Language.

## How It Works

1. The app starts directly with its logo name and menu stacked together, while the system prompting the user to choose from menu.

    - If the user wants to add a student record to the system, he needs to choose number 1.

    - Else if the user wants to view all the records
recorded in the system, he needs to choose number 2.

    - Else if the user only wants to know if a certain record is recorded in the
system, he needs to choose number 3.
    - And the last number is for exit/stop of the system.

2. In the Add Section, the user first needs to choose the specific Student Course he wants to record or return back to menu.
Then the user can enter the student record information. After clicking enter, the record is being recorded. The user can
record student record again.

3. In the View Section, the user can view all the records recorded in the specific student course which was
should be specified by the user upon entering the section. Then, the user can return back to menu.

4. In the Search Section, the user can enter the name of a student he wants to ensure if it is recorded in the system.
If the student's name existed, the system will echo "Record Found!!!!", otherwise "Record Not Found!!!!"
