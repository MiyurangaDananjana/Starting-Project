using System.ComponentModel.DataAnnotations;

namespace Starting_Project.Models.Entities
{
    public class Employer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Nationality { get; set; }

        public string CurrentResidence { get; set; }

        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public Question question { get; set; }
    }
}
