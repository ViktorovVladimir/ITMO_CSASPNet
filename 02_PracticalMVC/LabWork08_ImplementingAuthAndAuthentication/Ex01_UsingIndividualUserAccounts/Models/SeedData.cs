using Microsoft.EntityFrameworkCore;
using Ex01_UsingIndividualUserAccounts.Data;

namespace Ex01_UsingIndividualUserAccounts.Models
{
    public class SeedData
    {   
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CreditContextClass(
            serviceProvider.GetRequiredService<
            DbContextOptions<CreditContextClass>>()))
            {   
                if( context == null || context.Credits == null )
                {
                    throw new ArgumentNullException("Null CreditContext");
                }
                // Если в базе данных уже есть кредиты,
                // то возвращается инициализатор заполнения и кредиты не добавляются
                if( context.Credits.Any() )
                {
                    return;
                }
                context.Credits.Add(new CreditClass { Head = "Ипотечный", Period = 10, Sum = 1000000, Procent = 15 });

                context.Credits.Add(new CreditClass { Head = "Образовательный", Period = 7, Sum = 300000, Procent = 10 });
                context.Credits.Add(new CreditClass { Head = "Потребительский", Period = 5, Sum = 500000, Procent = 19 });
                // можно использовать метод AddRange
                context.Credits.AddRange(
                new CreditClass
                {
                    Head = "Льготный",
                    Period = 12,
                    Sum = 55555,
                    Procent = 7
                },
                new CreditClass
                {
                    Head = "Срочный",
                    Period = 3,
                    Sum = 3333,
                    Procent = 19
                }
                );
                context.SaveChanges();
            }   
        }
    }   
}