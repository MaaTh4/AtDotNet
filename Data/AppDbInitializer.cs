using AssementDotNet.AtDotnet.Models;

namespace AssementDotNet.AtDotnet.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviseScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviseScope.ServiceProvider.GetService<AssementDotNetContext>();

                context.Database.EnsureCreated();
                if (!context.PersonagemCreator.Any())
                {
                    context.PersonagemCreator.AddRange(new List<PersonagemCreator>(){
                        new PersonagemCreator()
                        {
                            age = 28,
                            name = "Vex",
                            classe = "Caçadora",
                            poder = "Arco e Flecha",
                            raca = "Elfo"

                        }
                    });
                }
                context.SaveChanges();
            }

        }
    }
}


