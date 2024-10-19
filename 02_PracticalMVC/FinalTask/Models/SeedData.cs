using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using FinalTask.Models;
using FinalTask.Data;

//--.
namespace FinalTask.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReportContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<ReportContext>>()))
            {
                //--.
                if( context == null || context.Disciplines == null )
                {
                    throw new ArgumentNullException("Null ReportContext");
                }
                // If there are already ReportCards in the database,
                // then the padding initializer is returned and credits are not added
                if ( context.Disciplines.Any() )
                {
                    return;
                }
                context.Disciplines.Add(new Discipline { Name = "Русский язык", TeacherName = "Иванова И.И." });
                context.Disciplines.Add(new Discipline { Name = "Литература", TeacherName = "Иванова И.И." });
                context.Disciplines.Add(new Discipline { Name = "Математика", TeacherName = "Козлов Д.Б." });
                context.Disciplines.Add(new Discipline { Name = "Физика", TeacherName = "Митрофанов В.Г." });

                //-- you can use the AddRange method
                context.Disciplines.AddRange(
                new Discipline
                {
                    Name = "Физическая культура",
                    TeacherName = "Орлов Д.Н"
                },
                new Discipline
                {
                    Name = "Биология",
                    TeacherName = "Фирсов К.Ю."
                }
                );
                context.SaveChanges();
            }
        }
    }
}

