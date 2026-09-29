using System;

class Program
{
    static void Main(string[] args)
    {

        Job job1 = new()
        {
            _company = "HP Inc.",
            _jobTitle = "Cloud Cafe Technician",
            _startYear = 2020,
            _endYear = 2022,
        };

        Job job2 = new()
        {
            _company = "Sparkie Inc.",
            _jobTitle = "Lead Software Engineer",
            _startYear = 2024,
            _endYear = 2026,
        };

        Resume resume1 = new()
        {
            _name = "Jonas Kennedy"
        };

        resume1._jobs.AddRange(job1, job2);

        resume1.Display();

    }
}