namespace AlmightyWarlords.Models
{
    using System;

    public class User
    {
        public long Id { get; set; }

        public string Pseudo { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PictureUrl { get; set; }

        public string Language { get; set; }

        public bool IsActivated { get; set; }

        public string CguVersion { get; set; }

        public DateTime? DateRemoval { get; set; }

        public DateTime DateLastConnection { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModification { get; set; }
    }
}
