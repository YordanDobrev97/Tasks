using System;

namespace NetSalary
{
    class Program
    {
        public const double INCOME_TAX = 0.10;
        public const double SOCIAL_CONTRIBUTIONS = 0.15;
        public const int IDR = 1000;
        
        public static double SocialContribution(double incomeTax, double grossSalary)
        {
            return (incomeTax - (grossSalary % IDR)) * SOCIAL_CONTRIBUTIONS;
        }

        public static double AddSocialContribution(double grossSalary, double incomeTax, double socialContribution)
        {
            return grossSalary - (incomeTax + socialContribution);     
        }

        public static bool IsPossibleSocialContribution(double grossSalary, double incomeTax, double socialContribution)
        {
            return grossSalary - (incomeTax + socialContribution) < 3000;
        }
        
        public static double CalculateNetSalary(double grossSalary)
        {
            //CalculateNetSalary is the method of adding new taxes to the relevant requirements
            
            double netSalary = grossSalary;
            if (grossSalary > IDR)
            {
                double incomeTax = (grossSalary  - IDR) * INCOME_TAX;
                double socialContribution = SocialContribution((grossSalary  - IDR), grossSalary);

                if (IsPossibleSocialContribution(grossSalary, incomeTax, socialContribution))
                {
                    netSalary = AddSocialContribution(grossSalary, incomeTax, socialContribution);
                }
            }
            
            return netSalary;
        }
        
        static void Main()
        {
            double grossSalary = double.Parse(Console.ReadLine());
            double netSalary = CalculateNetSalary(grossSalary);
            Console.WriteLine(netSalary);
        }
    }
}