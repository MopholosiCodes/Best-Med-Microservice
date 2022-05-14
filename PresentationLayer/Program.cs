using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;


namespace gradedLab
{
    class Program
    {
        private float penaltyPremium;
        private string newMember;
        private int count;
        private float totalPremium;

        static void Main(string[] args)
        {
            PremiumCalculator Calculator = new PremiumCalculator();
            Program program = new Program();

            program.newMember = "Y";
            while (program.newMember == "Y")
            {
                Console.Write("Add new member? press Y/N  ");
                var result = Console.ReadLine();

                if (result.ToUpper() == "Y")
                {
                    // main member form
                    Console.Write("Enter main members name: ");
                    var mainMemberName = Console.ReadLine();
                    Console.Write("Enter main member age: ");
                    var mainMemberAge = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter main member income: ");
                    var mainMemberIncome = int.Parse(Console.ReadLine());

                    // dependents form
                    Console.Write("Enter number of adult dependents: ");
                    var adultDependents = int.Parse(Console.ReadLine());
                    Console.Write("Enter number of child dependents: ");
                    var childDependents = int.Parse(Console.ReadLine());

                    var premuim = Calculator.calcMonthlyPremium(mainMemberIncome, childDependents, adultDependents);
                    var monthlyPremium = premuim;
                    var premiumPenalties = Calculator.calcPremiumPenalties(program.penaltyPremium, mainMemberAge, monthlyPremium);

                    // display resault
                    Console.WriteLine($"{program.count}. {mainMemberName} (age {mainMemberAge}) has {adultDependents} adult dependents and {childDependents} child dependents. " +
                        $"He/She will pay R{premiumPenalties} p/Month");

                    // add up total premiums
                    program.totalPremium += premiumPenalties;
                    program.count++;
                }
                else if (result.ToUpper() == "N")
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"The total premium is R{program.totalPremium}");
                    Console.WriteLine("----------------------------------------");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }  
}
