namespace bees_management_system
{
    class Queen : Bee
    {
        public Queen(Worker[] workers, double weightMg)
            : base(weightMg)
        {
            this.workers = workers;
        }

        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            shiftNumber++;
            string report = "Shift report number " + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DidYouFinish())
                    report += "Bee number " + (i + 1) + " has just finished its job\r\n";
                if (string.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Bee number " + (i + 1) + " isn't working\r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                    report += "Bee number " + (i + 1) + " is working. '" + workers[i].CurrentJob + "' will be her job for " + workers[i].ShiftsLeft + " more shifts\r\n";
                else
                    report += "Bee number " + (i + 1) + " is about to finish the job. '" + workers[i].CurrentJob + "' will be done after this shift\r\n"; 
            }
            return report;
        }
    }
}