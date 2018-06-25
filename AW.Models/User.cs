namespace AW.Models
{
    using System;

    public class User
    {
        public long Id { get; set; }

        public string Pseudo { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string PictureUrl { get; set; }

        public string Language { get; set; }

        public bool IsActivated { get; set; }

        public string CguVersion { get; set; }

        public DateTime? RemovalDate { get; set; }

        public DateTime LastConnectionDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
