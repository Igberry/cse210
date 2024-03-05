using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create job instances
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Display job details
        job1.Display();
        job2.Display();

        // Create resume instance
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Display resume details
        myResume.Display();
    }
}
