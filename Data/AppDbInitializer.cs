using BagShop.Data.Static;
using BagShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BagShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Designers
                if (!context.Designers.Any())
                {
                    context.Designers.AddRange(new List<Designer>()
                    {
                        new Designer()
                        {
                            Surname = "Ghesquière",
                            Name = "Nicolas",
                            BirthdayYear = 1971,
                            Nationality = "French"
                        },
                        new Designer()
                        {
                            Surname = "Anderson",
                            Name = "Jonathan",
                            BirthdayYear = 1984,
                            Nationality = "Great Britain"
                        },
                        new Designer()
                        {
                            Surname = "Galliano",
                            Name = "John",
                            BirthdayYear = 1960,
                            Nationality = "Great Britain"
                        },
                        new Designer()
                        {
                            Surname = "Michele",
                            Name = "Alessandro",
                            BirthdayYear = 1972,
                            Nationality = "Italian"
                        },
                        new Designer()
                        {
                            Surname = "Chanel",
                            Name = "Gabrielle",
                            BirthdayYear = 1883,
                            Nationality = "French"
                        },
                        new Designer()
                        {
                            Surname = "Birkin ",
                            Name = "Jane",
                            BirthdayYear = 1946,
                            Nationality = "Great Britain"
                        },
                    });
                    context.SaveChanges();
                }
                //Materials
                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(new List<Material>()
                    {
                        new Material()
                        {
                            Name = "Leather",
                            Description = "A material made from the skin of an animal by tanning or a similar process",
                            Density = 0.86M,
                            Price = 2.95M
                        },
                        new Material()
                        {
                            Name = "Stainless steel",
                            Description = "Stainless steel is an alloy of iron that is resistant to rusting and corrosion. ",
                            Density = 7500M,
                            Price = 235M
                        },
                        new Material()
                        {
                            Name = "Nylon",
                            Description = "Nylon is a silk-like thermoplastic, generally made from petroleum.",
                            Density = 1.14M,
                            Price = 3.2M
                        },
                        new Material()
                        {
                            Name = "Rope",
                            Description = "a length of thick strong cord made by twisting together strands of hemp, sisal, nylon, or similar material.",
                            Density = 0.55M,
                            Price = 0.87M
                        },
                    });
                    context.SaveChanges();
                }
                //Manufacturers
                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.AddRange(new List<Manufacturer>()
                    {
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1_ctY1EKmZ7zQM5KD0MQKjkGdq2D8VrSq",
                            Name = "Gucci",
                            FoundationYear = 1921
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=17aEMROWjtuuSFZ-IQIsldxJBE82HFute",
                            Name = "Dior",
                            FoundationYear = 1947
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1eIZ1jIO_oam7C9R2ZtoFecWQW-ApV9Kt",
                            Name = "Hermes",
                            FoundationYear = 1837
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1n5gTvcomhn4RbvVzBNvAk7QFAs24f8Qn",
                            Name = "Loewe",
                            FoundationYear = 1846
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=15CqyvkNzMw1gG3_iboDehLy1NkiLTrdu",
                            Name = "Louis Vitton",
                            FoundationYear = 1854
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1kZu4f7Z4y8x4EDTPIVD2R0ESeH-zdsBH",
                            Name = "Prada",
                            FoundationYear = 1913
                        },
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1VJeKMOufaHK6bpmLlkFsMqCaf7R1ltwZ",
                            Name = "Channel",
                            FoundationYear = 1910
                        }, 
                        new Manufacturer()
                        {
                            ManufacturerLogoURL = "http://drive.google.com/uc?export=view&id=1VN8mHfmTQVtJPtFibg26lX-H8I6l2Z4Y",
                            Name = "Balenciaga",
                            FoundationYear = 1919
                        }
                    });
                    context.SaveChanges();
                }
                //Bags
                if (!context.Bags.Any())
                {
                    context.Bags.AddRange(new List<Bag>()
                    {
                        new Bag()
                        {
                            Name = "Birkin", 
                            Description = "The Birkin bag (or simply Birkin) is a kind of tote bag introduced in 1984 by the French luxury goods maker Hermès.",
                            Price = 300000,
                            ImageURL = "http://drive.google.com/uc?export=view&id=1Y4pAPFhRG2Vc7D_thPaJNshsKUr9yU_u",
                            DesignerId = 6,
                            ManufacturerId = 3, 
                            BagCategory = BagCategory.Elegant
                        },                        
                        new Bag()
                        {
                            Name = "Crossbody",
                            Description = "The Chanel Classic Double flap bag is known for its double flap opening, diamond quilting pattern, iconic turn lock CC logo, and rich burgundy interior.",
                            Price = 6950,
                            ImageURL = "http://drive.google.com/uc?export=view&id=1gcB3KNqO6KDjQe8txAWTaa2F3oXtcijV",
                            DesignerId = 1,
                            ManufacturerId = 7, 
                            BagCategory = BagCategory.Elegant
                        },
                        new Bag()
                        {
                            Name = "Jackie",
                            Description = "A handbag roundup is not complete without mentioning Gucci, and the brand's Jackie bag has become a classic.",
                            Price = 2220,
                            ImageURL = "http://drive.google.com/uc?export=view&id=1GpEuim67Rri0fYeCliSqw7LTpuN6TpEY",
                            DesignerId = 4,
                            ManufacturerId = 7, 
                            BagCategory = BagCategory.Elegant
                        },
                        new Bag()
                        {
                            Name = "City bag",
                            Description = "We'll just go ahead and say it: Mary-Kate and Ashley Olsen are basically single-handedly responsible for the popularity of this bag. ",
                            Price = 1690,
                            ImageURL = "http://drive.google.com/uc?export=view&id=1fqLwo1tFn1WcS4QqIIhjrGk-rj9GE9JM",
                            DesignerId = 1,
                            ManufacturerId = 8, 
                            BagCategory = BagCategory.Elegant
                        },
                        new Bag()
                        {
                            Name = "Saddle Bag",
                            Description = "Dior's first Saddle Bag debuted in 1999 when John Galliano was still at the helm of the house, and its high resale value is proof that it's still coveted today.",
                            Price = 3250,
                            ImageURL = "http://drive.google.com/uc?export=view&id=14GwLzvSo2RJzpouxgC82SIWVga1EyerK",
                            DesignerId = 3,
                            ManufacturerId = 2,
                            BagCategory = BagCategory.Elegant
                        },
                        new Bag()
                        {
                            Name = "Puzzle Bag",
                            Description = "While Chanel and Louis Vuitton bags are recognisable to the masses, Loewe bags are a bit more niche for fashion people in the know—making them all the more desirable for discerning customers. ",
                            Price = 1700,
                            ImageURL = "http://drive.google.com/uc?export=view&id=1b_WHvxMTbbGAqCPPyTvmjQK26NEHRRZD",
                            DesignerId = 2,
                            ManufacturerId = 4, 
                            BagCategory = BagCategory.Elegant
                        },
                        new Bag()
                        {
                            Name = "Speedy",
                            Description = "The first bag Louis Vuitton ever created, the Speedy was a surefire hit straight from its conception in the 1930s and has since been carried by some of the most glamorous women of our time.",
                            Price = 2500,
                            ImageURL = "http://drive.google.com/uc?export=view&id=11dkZkOQTFNpMh062FOU7O3fvpEHi8b0C",
                            DesignerId = 5,
                            ManufacturerId = 5,
                            BagCategory = BagCategory.Elegant
                        },
                    });
                    context.SaveChanges();
                }
                //Materials and Bags list relation
                if (!context.Materials_Bags.Any())
                {
                    context.Materials_Bags.AddRange(new List<Material_Bag>()
                    {
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 3
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 3
                        },

                         new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 1
                        },
                         new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 1
                        },
                         new Material_Bag()
                        {
                            MaterialId = 1,
                            BagId = 1
                        },
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 2
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 2
                        },
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 4
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 4
                        },
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 5
                        },
                        new Material_Bag()
                        {
                            MaterialId = 1,
                            BagId = 5
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 5
                        },
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 6
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 6
                        },
                        new Material_Bag()
                        {
                            MaterialId = 2,
                            BagId = 7
                        },
                        new Material_Bag()
                        {
                            MaterialId = 3,
                            BagId = 7
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@bagshop.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Adminuser1234!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@bagshop.com";
                 
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Adminuser1234!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
