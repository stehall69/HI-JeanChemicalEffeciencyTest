using System;
using System.Collections.Generic;
using System.Globalization;

namespace HI_JeanChemicalEffeciencyTest
{
    class Program
    {
        //global Variables
        static string ChemEffLowName;
        static double ChemEffLow = 100;
        static double ChemEffHigh = 0;
        static string ChemEffHighName;

        //ERROR Control
        static string CheckTestChemical()
        {
            while (true)
            {
                Console.WriteLine("\nPress <ENTER> to Test a chemical or Type 'stop' to quit:\n");


                string checkChoice = Console.ReadLine().ToLower();
                if (checkChoice.Equals("stop") || checkChoice.Equals(""))
                {
                    return checkChoice;
                }
                Console.WriteLine("ERROR: please enter a correct choice");
            }

        }
        static float CheckFloat(string question, float min, float max)
        {
            string ERROR_MSG = $"Error: Enter a valid number between {min} and {max}";

            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    float userFloat = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
                    if (userFloat >= min && userFloat <= max)
                    {
                        return userFloat;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(ERROR_MSG);

                    }

                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine(ERROR_MSG);

                }
            }
        }



        static void Main(string[] args)
        {
            //welcome message
            Console.WriteLine("<Welcome to HI-Jean cleaning chemical efficiency testing>\n\n");

            Console.WriteLine("You will need to:\n" +
                "*Enter the chemical you used\n" +
                "*Enter the amount of germs on the sample before cleaning\n" +
                "*Enter the amount of germs on the sample after cleaning\n" +
                "*Enter the amount of time it took in seconds\n" +
                "This process needs to be repeated 5 Times per chemical\n\n ");

            
            
            //menu
            bool flag1 = true;
            while (flag1)
            {

                string UserChoice = CheckTestChemical();
                
                
                if (UserChoice.Equals("stop"))
                {
                    Console.WriteLine("\nThank you for using HI-Jean chemical test do not give up your scientific endevours!!\n");

                    Console.WriteLine($"your most effective chemical is {ChemEffHighName} whith an effeicency of: {ChemEffHigh}\nAnd your least effective chemical is {ChemEffLowName} with an effecincy of {ChemEffLow}");
                    
                    flag1 = false;
                }
                else if (UserChoice.Equals(""))
                {
                    
                    ChemicalTest();
                }
            }
            
        }
        static void ChemicalTest()
        {

            float germCount1 = 0;           
            
            germCount1 = Convert.ToInt32(CheckFloat("Please enter the amount of germ colonies on Your sample before cleaning 1-150\n", 1, 150));

            List<string> ChemicalNames = new List<string> { "Hypochlorite", "Alchols", "Chlorine Dioxide", "Hydrogen & Peracitic Acid", "Sodium" };

            

            int chemical = Convert.ToInt32(CheckFloat($"\nPlease select the chemical you used by typing the number correspondent to that chemical: \n1 = {ChemicalNames[0]}, \n2 = {ChemicalNames[1]}, \n3 = {ChemicalNames[2]}, \n4 = {ChemicalNames[3]}, \n5 = {ChemicalNames[4]} \n",1,5)) - 1;

            
            //test efficiency
            double test1Effeciency = 0;
            double test2Effeciency = 0;
            double test3Effeciency = 0;
            double test4Effeciency = 0;
            double test5Effeciency = 0;




            //Test 1 chemical
            for (int testCount = 1; testCount < 6; testCount++)
            {
                float germCount2 = 0;

                Console.WriteLine($"\n        <><><><><><>TEST {testCount}<><><><><><>\n");

                

                germCount2 = CheckFloat($" Please enter the amount of germs left after cleaning\n",1,149);
                
                if (germCount2 > germCount1)
                {
                    Console.WriteLine("\nERROR: AMOUNT OF GERMS AFTER CLEANING IS NOT LESS THEN ORIGINAL GERM COUNT");
                    Console.WriteLine($" Please enter the amount of germs left after cleaning\n");

                    germCount2 = Convert.ToInt32(Console.ReadLine());

                }

                

                double testTime = Convert.ToInt32(CheckFloat("Please enter the amount of time you tested for in seconds 150-1000 \n",150,1000));
                
                if (testCount == 1)
                {
                   test1Effeciency = (germCount1 - germCount2) / testTime;
                   test1Effeciency = Math.Round(test1Effeciency, 2);
                    
                    Console.WriteLine($"\neffeciency for test 1 is :{test1Effeciency}");
                    
                    Console.WriteLine($"\n        <><><><><><>TEST {testCount} END<><><><><><>");
                }
                else if (testCount == 2)
                {
                    test2Effeciency = (germCount1 - germCount2) / testTime;

                    test2Effeciency = Math.Round(test2Effeciency, 2);

                    Console.WriteLine($"\neffeciency for test 2 is :{test2Effeciency}");
                    
                    Console.WriteLine($"\n        <><><><><><>TEST {testCount} END<><><><><><>");
                }
                else if (testCount == 3)
                {
                    test3Effeciency = (germCount1 - germCount2) / testTime;

                    test3Effeciency = Math.Round(test3Effeciency, 2);

                    Console.WriteLine($"\neffeciency for test 3 is :{test3Effeciency}");
                    
                    Console.WriteLine($"\n        <><><><><><>TEST {testCount} END<><><><><><>");
                }
                else if (testCount == 4)
                {
                    test4Effeciency = (germCount1 - germCount2) / testTime;

                    test4Effeciency = Math.Round(test4Effeciency, 2);

                    Console.WriteLine($"\neffeciency for test 4 is :{test4Effeciency}");
                    
                    Console.WriteLine($"\n        <><><><><><>TEST {testCount} END<><><><><><>");
                }
                else if (testCount == 5)
                {
                    test5Effeciency = (germCount1 - germCount2) / testTime;

                    test5Effeciency = Math.Round(test5Effeciency, 2);

                    Console.WriteLine($"\neffeciency for test 5 is :{test5Effeciency}");
                    
                    Console.WriteLine($"\n        <><><><><><>TEST {testCount} END<><><><><><>");
                }
            }
            double chemicalEffeciency = (test1Effeciency + test2Effeciency + test3Effeciency + test4Effeciency + test5Effeciency) / 5;


            Math.Round(chemicalEffeciency, 2);
            
            Console.WriteLine($"\n effeciency for {ChemicalNames[chemical]} is: {chemicalEffeciency}");
            
            //compare chemEff high/low
            if(chemicalEffeciency > ChemEffHigh)
            {
                ChemEffHigh = chemicalEffeciency;
                ChemEffHighName = ChemicalNames[chemical];
                Math.Round(ChemEffHigh, 2);
            }
            
            if(chemicalEffeciency < ChemEffLow)
            {
                ChemEffLow = chemicalEffeciency;
                ChemEffLowName = ChemicalNames[chemical];
                Math.Round(ChemEffLow, 2);
            }
        }
    }
}
