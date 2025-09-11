using System;

class IntergalacticCinema
{
    static void Main()
    {
        Action<string> wl = Console.WriteLine;
        Func<string> rl = () =>
        {
            string? input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Invalid input, try again:");
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        };
        
        wl("Enter your age (0 - 120): ");
        int age;
        while (true)
        {
            if (int.TryParse(rl(), out age) && age >= 0 && age <= 120)
                break;
            else
                wl("Incorrect input, try again: ");
        }

        wl("Enter the movie type (premiere, classic, 3D, marathon, special_function): ");
        string movieType = rl().ToLower();

        wl("Enter the day (monday, tuesday, wednesday, thursday, friday, saturday, sunday): ");
        string day = rl().ToLower();

        wl("Enter the time (morning, afternoon, evening): ");
        string time = rl().ToLower();
        
        wl("Enter membership (none, silver, gold, platinum): ");
        string membership = rl().ToLower();
        
        bool ReadBool(string question)
        {
            wl(question);
            while (true)
            {
                string input = rl().ToLower();
                if (input == "true" || input == "yes")
                    return true;
                else if (input == "false" || input == "no")
                    return false;
                else
                    wl("Invalid input, enter true/false or yes/no: ");
            }
        }

        bool promoActive = ReadBool("Is there an active promo? (true/false or yes/no): ");
        bool student = ReadBool("Are you a student? (true/false or yes/no): ");
        bool couple = ReadBool("Are you coming as a couple? (true/false or yes/no): ");

        int basePrice = 10000;
        double finalPrice = basePrice;

        wl($"\nBase price: {basePrice}");
        
        if (age < 12)
        {
            if (movieType == "classic" && (day == "monday" || day == "wednesday"))
            {
                finalPrice = 0;
                wl("Children free on classics (Mon/Wed).");
            }
            else if (movieType == "3d" && (time == "morning" || time == "afternoon"))
            {
                finalPrice *= 0.3;
                wl("Children pay 30% on 3D before 6pm.");
            }
            else if (movieType == "special_function")
            {
                wl("Children cannot enter special functions.");
                return;
            }
        }
        else if (age >= 12 && age <= 17)
        {
            if (movieType == "classic" && day == "wednesday")
            {
                finalPrice *= 0.5;
                wl("Adolescents pay 50% on classics (Wed).");
            }
            if (membership == "silver" && movieType == "3d" && day != "sunday")
            {
                finalPrice *= 0.8;
                wl("Silver membership: 20% off 3D (except Sundays).");
            }
        }
        else if (age >= 18 && age <= 59)
        {
            if (membership == "gold")
            {
                if (movieType == "classic" && !(day == "friday" && time == "evening") && !(day == "saturday" && time == "evening"))
                {
                    finalPrice *= 0.75;
                    wl("Gold membership: 25% off classics (not Fri/Sat evening).");
                }
                if (movieType == "3d" && day != "sunday")
                {
                    finalPrice *= 0.85;
                    wl("Gold membership: 15% off 3D (not Sundays).");
                }
            }
            if (membership == "platinum")
            {
                if (movieType == "premiere" && (day == "saturday" && time == "evening"))
                {
                    wl("Platinum excluded: full price on premieres Saturday night.");
                }
                else
                {
                    finalPrice *= 0.65;
                    wl("Platinum membership: 35% discount.");
                }
            }
        }
        else if (age >= 60)
        {
            if (movieType == "marathon")
            {
                finalPrice *= 0.5;
                wl("Seniors pay 50% on marathon.");
            }
            else if (day == "sunday" && promoActive)
            {
                finalPrice *= 0.3;
                wl("Seniors 70% off on Sunday with active promo.");
            }
            else
            {
                finalPrice *= 0.6;
                wl("Seniors 40% discount.");
            }
        }

        if (day == "wednesday" && movieType != "special_function")
        {
            finalPrice *= 0.8;
            wl("Wednesday global discount: 20% off.");
        }
        if ((day == "friday" || day == "saturday") && time == "evening")
        {
            wl("Friday/Saturday evening: no membership discounts allowed.");
        }

        if (movieType == "premiere")
        {
            if (student)
            {
                finalPrice *= 0.85;
                wl("Student discount: 15% on premieres.");
            }
            else if (membership == "platinum" && !(day == "saturday" && time == "evening"))
            {
                finalPrice *= 0.65;
                wl("Platinum: 35% off on premieres (not Sat evening).");
            }
        }
        else if (movieType == "3d")
        {
            finalPrice *= 1.1;
            wl("3D recargo: +10% after discounts.");
        }
        else if (movieType == "marathon")
        {
            if (age < 60)
            {
                finalPrice *= 0.8;
                wl("Marathon: 20% global discount.");
            }
        }
        else if (movieType == "special_function")
        {
            if (age < 18)
            {
                wl("Only adults and seniors allowed in special functions.");
                return;
            }
        }

        if (student && (day == "monday" || day == "wednesday"))
        {
            finalPrice *= 0.9;
            wl("Extra student discount 10% (Mon/Wed).");
        }
        if (couple && day != "sunday")
        {
            finalPrice = finalPrice + (finalPrice * 0.5);
            wl("Couple promo: second ticket 50% off (not Sundays).");
        }
        if (promoActive)
        {
            if (day == "sunday" && movieType != "special_function")
            {
                finalPrice *= 0.9;
                wl("Sunday promo: 10% extra off.");
            }
            else if (day != "sunday" && (membership == "silver" || membership == "gold" || membership == "platinum"))
            {
                finalPrice *= 0.95;
                wl("Promo active: +5% off for Silver+ memberships.");
            }
        }
        
        wl($"\nFinal price: {Math.Round(finalPrice)}");
    }
}
