using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoAppGestionCapacitacionesUNED.DbContext;
using ProyectoAppGestionCapacitacionesUNED.Helpers;
using ProyectoAppGestionCapacitacionesUNED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAppGestionCapacitacionesUNED.Data
{
    public class DBInitializer : IDBInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            //Add pending migration if exists
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }

            //Exit if role already exists
            if (_db.Roles.Any(r => r.Name == Helpers.Roles.Admin)) return;


            //Create Admin role
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();

            //Create Admin user
            _userManager.CreateAsync(new ApplicationUser
            {

                UserName = "pcanipa@uned.ac.cr",
                Email = "pcanipa@uned.ac.cr",
                EmailConfirmed = true,


            }, "Uned.151061").GetAwaiter().GetResult();

            //Assign role to admin user
            await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync("pcanipa@uned.ac.cr"), Roles.Admin);
        }

    }
}
