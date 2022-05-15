using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PremiumCalculator
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Index : System.Web.Services.WebService
    {
        private float penaltyPremium;

        [WebMethod]
        public string CalculatePremium(string name, int age, float income, int adultDependents, int childDependents)
        {
            PremiumCalculator Calculator = new PremiumCalculator();
            Index program = new Index();

            var premuim = Calculator.calcMonthlyPremium(income, childDependents, adultDependents);
            var monthlyPremium = premuim;
            var premiumPenalties = Calculator.calcPremiumPenalties(program.penaltyPremium, age, monthlyPremium);

            return $"{name} (age {age}) has {adultDependents} adult dependents and {childDependents} child dependents. " +
                        $"He/She will pay R{premiumPenalties} p/Month";
        }
    }
}
