﻿using Microsoft.AspNetCore.Identity;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Configuration
{
    public static class ConfigurationHelper
    {
        public static IdentityUser TestUser { get; set; } = GetUser();

        public static Board OpenBoard { get; set; } = new Board() { Id = 1, Name = "Open" };
        public static Board InProggressBoard { get; set; } = new Board() { Id = 2, Name = "In Proggress" };
        public static Board DoneBoard { get; set; } = new Board() { Id =3, Name = "Done" };

        private static IdentityUser GetUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            user.PasswordHash = hasher.HashPassword(user, "softuni");

            return user;
        }

    }


}
