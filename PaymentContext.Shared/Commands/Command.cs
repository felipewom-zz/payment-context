using Flunt.Notifications;

namespace PaymentContext.Shared.Commands
{
    public abstract class Command : Notifiable
    {
        public abstract void Validate();
    }
}