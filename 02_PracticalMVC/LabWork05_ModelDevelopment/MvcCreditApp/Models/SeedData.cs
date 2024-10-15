using Microsoft.EntityFrameworkCore;
using MvcCreditApp.Data;

namespace MvcCreditApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CreditContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<CreditContext>>()))
            {
                if (context == null || context.Credits == null)
                {
                    throw new ArgumentNullException("Null CreditContext");
                }
                // Если в базе данных уже есть кредиты,
                // то возвращается инициализатор заполнения и кредиты не добавляются
                if (context.Credits.Any())
                {
                    return;
                }
                context.Credits.Add(new Credit { Head = "Ипотечный", Period = 10, Sum = 1000000, Procent = 15 });

                context.Credits.Add(new Credit { Head = "Образовательный", Period = 7, Sum = 300000, Procent = 10 });
                context.Credits.Add(new Credit { Head = "Потребительский", Period = 5, Sum = 500000, Procent = 19 });
                // можно использовать метод AddRange
                context.Credits.AddRange(
                new Credit
                {
                    Head = "Льготный",
                    Period = 12,
                    Sum = 55555,
                    Procent = 7
                },
                new Credit
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