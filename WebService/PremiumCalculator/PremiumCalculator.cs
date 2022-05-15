using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PremiumCalculator
{
    public class PremiumCalculator
    {
        public int maxChildDependent { get { return 3; } }
        private float monthlyPremium;
        private float childDependentPremium;
        private float adultDependentPremium;

        // calculate monthly premium based on income bracket
        public float calcMonthlyPremium(float income, int childDependents, int adultDependents)
        {
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
                if (childDependents <= maxChildDependent)
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