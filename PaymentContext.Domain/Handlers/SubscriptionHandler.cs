using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IEmailService _emailService;
        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Fast
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            AddNotifications(command);
            // Verificar se documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Documeto já está em uso");
            }

            // Verificar se email já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Email já está em uso");
            }

            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
                command.Country, command.ZipCode);
            // Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.PaidDate,
                command.ExpireDate,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email,
                command.Payer,
                command.Total,
                command.TotalPaid,
                command.BarCode,
                command.BoletoNumber
            );
            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            // Aplicar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            // Checar as notificações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            // Salvar as Informações
            _repository.CreateSubscription(student);
            // Enviar email de boas vindas
            _emailService.Send(command.Email, "mdr@gmail.com", "Bem vindo ao MDR", "Parabéns, agora você faz parte do Time!");
            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // Fail Fast
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            AddNotifications(command);
            // Verificar se documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Documeto já está em uso");
            }

            // Verificar se email já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Email já está em uso");
            }

            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
                command.Country, command.ZipCode);
            // Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.PaidDate,
                command.ExpireDate,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email,
                command.Payer,
                command.Total,
                command.TotalPaid,
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber
            );
            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            // Aplicar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            // Checar as notificações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            // Salvar as Informações
            _repository.CreateSubscription(student);
            // Enviar email de boas vindas
            _emailService.Send(command.Email, "mdr@gmail.com", "Bem vindo ao MDR", "Parabéns, agora você faz parte do Time!");
            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // Fail Fast
            command.Validate();
            if (command.Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            AddNotifications(command);
            // Verificar se documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Documeto já está em uso");
            }

            // Verificar se email já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Email já está em uso");
            }

            // Gerar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
                command.Country, command.ZipCode);
            // Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.PaidDate,
                command.ExpireDate,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                command.Total,
                command.TotalPaid,
                address,
                email,
                command.TransactionCode
            );
            // Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            // Aplicar as Validações
            AddNotifications(name, document, email, address, student, subscription, payment);
            // Checar as notificações
            if (Invalid)
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }
            // Salvar as Informações
            _repository.CreateSubscription(student);
            // Enviar email de boas vindas
            _emailService.Send(command.Email, "mdr@gmail.com", "Bem vindo ao MDR", "Parabéns, agora você faz parte do Time!");
            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}