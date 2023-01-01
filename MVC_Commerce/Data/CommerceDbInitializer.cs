using Microsoft.AspNetCore.Identity;
using MVC_Commerce.Data.Static;
using MVC_Commerce.Models;

namespace MVC_Commerce.Data
{
    public class CommerceDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CommerceContext>();

                context.Database.EnsureCreated();


                //Category
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category(){CategoryName="Electronics",CategoryDescription="Buy electronics for best price."},
                        new Category(){CategoryName="Home & Design",CategoryDescription="Buy the best decorations for your home."},
                        new Category(){CategoryName="Clothing",CategoryDescription="Clothing for your style."},
                    }
                    );
                    context.SaveChanges();
                }

                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Products>()
                    {
                        new Products(){ProductBrand="Apfel",ProductName="14 Pro XS Max",CategoryId=1,ProductPrice=60000,ProductQuantity=15,ProductDescription="Best Apfel phone on the market.",ProductImageURL="https://images.unsplash.com/photo-1580910051074-3eb694886505?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTR8fHBob25lfGVufDB8fDB8fA%3D%3D&w=1000&q=80",},
                        new Products(){ProductBrand="Zamzung",ProductName="S36 Pro",CategoryId=1,ProductPrice=40000,ProductQuantity=20,ProductDescription="Best Zamzung phone on the market.",ProductImageURL="https://www.91-img.com/gallery_images_uploads/3/7/3778df502ba00e33342e22b427da70d1fa16da1b.JPG?tr=h-550,w-0,c-at_max"},
                        new Products(){ProductBrand="IAKI",ProductName="Wooden Chair",CategoryId=2,ProductPrice=5000,ProductQuantity=12,ProductDescription="Chair for your style.",ProductImageURL="https://static8.depositphotos.com/1022715/834/i/950/depositphotos_8346493-stock-photo-wooden-chair-over-white-with.jpg"},
                        new Products(){ProductBrand="Aedro",ProductName="Tiny Table",CategoryId=2,ProductPrice=9000,ProductQuantity=46,ProductDescription="Table for your kitchen or guest room.",ProductImageURL="https://media.istockphoto.com/id/900257448/photo/wooden-round-table.jpg?s=612x612&w=0&k=20&c=xW86GqjC8IMqoWtAlCejOSuGlR7_YrM8jlBdufCro7Q="},
                        new Products(){ProductBrand="Lavi's",ProductName="Pants",CategoryId=3,ProductPrice=400,ProductQuantity=22,ProductDescription="Very stylish pants",ProductImageURL="https://thumbs.dreamstime.com/b/mens-pants-isolated-white-background-dress-trousers-against-98716291.jpg"},
                        new Products(){ProductBrand="M&H",ProductName="Grey Hoodie",CategoryId=3,ProductPrice=1300,ProductQuantity=22,ProductDescription="Chair for your style.",ProductImageURL="https://thumbs.dreamstime.com/b/men-grey-blank-hoodie-template-two-sides-natural-shape-invisible-mannequin-your-design-mockup-print-isolated-white-155842964.jpg"},
                    }
                   );
                    context.SaveChanges();

                }

                ////User
                //if (!context.Users.Any())
                //{
                //    context.Users.AddRange(new List<User>()
                //    {
                //        new User(){UserName="Burak",UserSurname="Akbas",UserEmail="test@gmail.com",UserBalance=500000,UserPhoneNumber="5342677529"},
                //        new User(){UserName="Seda",UserSurname="Mencik",UserEmail="test2@gmail.com",UserBalance=2000,UserPhoneNumber="5446778976"},
                //        new User(){UserName="Mahmut",UserSurname="Tuncer",UserEmail="test3@gmail.com",UserBalance=99000,UserPhoneNumber="5313617854"},
                //    }
                //    );
                //    context.SaveChanges();
                //}

                ////Comment
                //if (!context.Comments.Any())
                //{
                //    context.Comments.AddRange(new List<Comment>()
                //    {
                //        new Comment(){Title="Best Phone!",Description="I loved it.",UserId=1,ProductId=1},
                //        new Comment(){Title="I didn't like it :(",Description="Worst hoodie",UserId=2,ProductId=6},

                //    }
                //    );
                //    context.SaveChanges();

                //}

                ////Favourite
                //if (!context.Favourites.Any())
                //{
                //    context.Favourites.AddRange(new List<Favourite>()
                //    {
                //        new Favourite(){UserId=1,ProductId=1},
                //        new Favourite(){UserId=1,ProductId=5 },
                //        new Favourite(){UserId=2,ProductId=1 },
                //    }
                //    );
                //    context.SaveChanges();

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                //Roles

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //User
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserMail = "g201210050@sakarya.edu.tr";

                var adminUser = await userManager.FindByEmailAsync(adminUserMail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserMail,
                        NormalizedEmail= adminUserMail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "sau");
                    await userManager.AddToRoleAsync(newAdminUser,UserRoles.Admin);
                }

                string appUserMail = "test@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserMail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "App User",
                        UserName = "appUser",
                        Email = appUserMail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "sau");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}

