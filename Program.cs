using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradedLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            float penaltyPremium = 0;
            var newMember = "Y";
            var count = 1;
            float totalPremium = 0;

            while (newMember == "Y")
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


                    // instanciate methods
                    var premuim = program.calcMonthlyPremium(mainMemberIncome, childDependents, adultDependents);
                    var monthlyPremium = premuim;
                    var premiumPenalties = program.calcPremiumPenalties(penaltyPremium, mainMemberAge, monthlyPremium);

                    // display resault
                    Console.WriteLine($"{count}. {mainMemberName} (age {mainMemberAge}) has {adultDependents} adult dependents and {childDependents} child dependents. " +
                        $"He/She will pay R{premiumPenalties} p/Month");

                    // add up total premiums
                    totalPremium += premiumPenalties;
                    count++;
                }
                else if (result.ToUpper() == "N") // End program
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"The total premium is R{totalPremium}");
                    Console.WriteLine("----------------------------------------");
                    
                    Console.ReadKey();
                    break;
                }
            }
        }

        // calculate monthly premium based on income bracket
        public float calcMonthlyPremium(float income, int childDependents, int adultDependents)
        {
            var monthlyPremium = 0;
            var childDependentPremium = 0;
            var adultDependentPremium = 0;
            var maxChildDependent = 3;

            if (income < 7001.00)
            {
                if (childDependents <= maxChildDependent)
                    childDependentPremium = childDependents * 264;
                else childDependentPremium = maxChildDependent * 264;

                adultDependentPremium = adultDependents * 476;
                monthlyPremium = childDependentPremium + adultDependentPremium + 528;
            }
            else if (income > 7000.00 && income < 12000.00)
            {
                if(childDependents <= maxChildDependent)
                    childDependentPremium = childDependents * 470;
                else childDependentPremium = maxChildDependent * 470;

                adultDependentPremium = adultDependents * 709;
                monthlyPremium = childDependentPremium + adultDependentPremium + 868;
            }
            else if (income > 12001.00)
            {
                if (childDependents <= maxChildDependent)
                    childDependentPremium = childDependents * 586;
                else childDependentPremium = maxChildDependent * 586;

                adultDependentPremium = adultDependents * 887;
                monthlyPremium = childDependentPremium + adultDependentPremium + 1084;
            }

            return monthlyPremium;
        }

        // calculate penalty premium based on age
        public float calcPremiumPenalties(float penaltyPremium, int age, float monthlyPremium)
        {
            if (age > 35 && age < 40)
            {
                penaltyPremium = monthlyPremium + (monthlyPremium * 5 / 100);
            }
            else if (age > 39 && age < 50)
            {
                penaltyPremium = monthlyPremium + (monthlyPremium * 25 / 100);
            }
            else if (age > 50 && age < 60)
            {
                penaltyPremium = monthlyPremium + (monthlyPremium * 50 / 100);
            }
            else if (age > 60)
            {
                penaltyPremium = monthlyPremium + (monthlyPremium * 75 / 100);
            }
            else // default
            {
                penaltyPremium = monthlyPremium;
            }

            return penaltyPremium;
        }
    }
}
