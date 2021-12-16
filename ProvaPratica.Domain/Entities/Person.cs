namespace ProvaPratica.Domain.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; private set; }

        public int Age { get; private set; }

        public string Email { get; private set; }

        public int ExperienceYears { get; private set; }

        public Person(string? firstName, int age, string? email, int experienceYears) : base()
        {
            FirstName = firstName ?? "";
            Age = age;
            Email = email ?? "";
            ExperienceYears = experienceYears;
        }

        public void UpdateFirstName(string? firstName)
        {
            if (firstName != null)
                FirstName = firstName;
        }

        public void UpdateAge(int age)
        {
            if (age > 0)
                Age = age;
        }

        public void UpdateEmail(string? email)
        {
            if (email != null)
                Email = email;
        }

        public void UpdateExperienceYears(int experienceYears) => ExperienceYears = experienceYears;
    }
}
