using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class QuoteGen
    {
        double estimatedWorth=0;
        double engineSize;
        string licenceType;
        int yearOfBirth;
        bool noClaimsBonus;
        bool namedDriver;
        double IQuote=0;
        double temp;
       //Initial Quote
        /// <summary>
   
        /// </summary>
        public void InitialQuote()
        {
            //Estimated Worth
            estimatedWorth = Quote.estimatedWorth;
            engineSize = Quote.engineSize;
            licenceType = Quote.licenceType;
            yearOfBirth = Quote.yearOfBirth;
            noClaimsBonus = Quote.noClaimsBonus;
            namedDriver = Quote.namedDriver;
            
            DateTime moment =(DateTime.Now);
            int Age;
            int now = moment.Year;
            Age = yearOfBirth - now;


            IQuote = (7 / 100 * estimatedWorth);

            if(Age >= 17 && Age <= 25)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            else if(Age > 25 && Age <= 60)
            {
                temp = 4 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            else if(Age > 60)
            {
                temp = 7 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            //No Claims Bonus
            //Customer has No Claims Bonus
            if (noClaimsBonus == true)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote - temp;
            }
            //Customer doesn't have No Claims Bonus
            else if (noClaimsBonus == false)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }

            if(namedDriver == true)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }

            //Age
            //Where Age >= 17 and Age <= 25
            if(Age >= 17 && Age <= 25)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            //Where Age > 25 and Age <= 60
            else if(Age > 25 && Age <= 60)
            {
                temp = 4 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            //Where Age > 60
            else
            {
                temp = 7 / 100 * IQuote;
                IQuote = IQuote + temp;
            }

            //Licence Type
            //Full Licence - Do Nothing
            //Provisional Licence
            if (licenceType == "Full")
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }

            //Engine Size
            //Where Engine Size >= 0.7 and Engine Size <= 1.4
            if(engineSize >= 0.7 && engineSize <= 1.4)
            {
                temp = 4 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
            //Where Engine Size > 1.4 and Engine Size <= 1.9
            else if(engineSize > 1.4 && engineSize <= 1.9)
            {
                temp = 7 / 100 * IQuote;
                IQuote = IQuote + temp;
            }
         
            else if(engineSize > 1.9)
            {
                temp = 10 / 100 * IQuote;
                IQuote = IQuote + temp;
            }

            Console.WriteLine(IQuote);
        }
    }
}
