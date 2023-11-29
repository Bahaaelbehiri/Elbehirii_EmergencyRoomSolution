namespace Elbehirii_EmergencyRoom
{
    internal class Program
    {
        public static PriorityQueue<Patient, int> myqueue = new PriorityQueue<Patient, int>();
        static void Main(string[] args)
        {
            string ReaderLastname;
            string ReaderFirstname;
            string ReaderBirthday;
            int Readerpriorty;


            StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\Patients.csv");
            string? currLine = sr.ReadLine();

            while (currLine != null)
            {
                currLine = sr.ReadLine();
                if (currLine == null) { continue; }
                Patient newPat = new Patient(currLine.Split(',')[0], currLine.Split(',')[1], currLine.Split(',')[2], int.Parse(currLine.Split(',')[3]));
                myqueue.Enqueue(newPat, newPat.priority);
            }

            sr.Close();

            char choice;


            do
            {
                
                Console.WriteLine("=== Main Menu ====");
                Console.WriteLine("===================");
                Console.WriteLine("(A)dd Patient  (P)rocess Current Patient  (L)ist All in Queue  (Q)uit");
                Console.WriteLine("===================");
                Console.Write("    'hot' key as shown above in parenthesis:  ");
                try
                {
                    choice = Convert.ToChar(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write(" Choose next choice: ");
                    choice = Convert.ToChar(Console.ReadLine());

                }
                switch (choice)
                {

                    case 'A':

                        Console.Write("Patient Lastname:  ");
                        ReaderLastname = Convert.ToString(Console.ReadLine());
                        Console.Write("Patient Firstname:  ");
                        ReaderFirstname = Convert.ToString(Console.ReadLine());
                        Console.Write("Patient Birthday:  ");
                        ReaderBirthday = Convert.ToString(Console.ReadLine());

                        Console.Write("Priority (1:highest priority – 5:lowest priority) ");
                        Readerpriorty = Convert.ToInt32(Console.ReadLine());
                        if (Readerpriorty > 5 || Readerpriorty < 1)
                        {
                            Console.Write("Priority (1:highest priority – 5:lowest priority)");
                            Readerpriorty = Convert.ToInt32(Console.ReadLine());
                        }

                        Patient er = new Patient(ReaderLastname, ReaderFirstname, ReaderBirthday, Readerpriorty);
                        // priorty1 = Convert.ToInt32(Console.ReadLine());


                        Patient e1 = new Patient(ReaderLastname, ReaderFirstname, ReaderBirthday, Readerpriorty);
                        myqueue.Enqueue(e1, e1.priority);

                        break;

                    case 'P':

                        //if (myqueue.Count > 0)
                        Console.WriteLine(myqueue.Dequeue());

                        break;

                    case 'L':

                        Disp();

                        break;

                    case 'Q':

                        break;

                }

            } while (choice != 'Q');

        }
        static public void Disp()
        {
            PriorityQueue<Patient, int> tempQueue = new PriorityQueue<Patient, int>();
            int listCount = myqueue.Count;
            for (int item = 0; item < listCount; item++)
            {
                Patient tempPatient = myqueue.Dequeue();
                Console.WriteLine(tempPatient.ToString());
                tempQueue.Enqueue(tempPatient, tempPatient.priority);
            }
            listCount = tempQueue.Count;
            for (int item = 0; item < listCount; item++)
            {
                Patient tempPatient = tempQueue.Dequeue();
                myqueue.Enqueue(tempPatient, tempPatient.priority);
            }
        }
    }
}
