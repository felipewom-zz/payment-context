using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Primeiro nome inválido, deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "Name.FirstName", "Primeiro nome inválido, deve conter menos de 40 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "Último nome inválido, deve conter pelo menos 3 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}