using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDio2
{
    internal class PluginPostOperation
    {
        private void OnPostValidation(IServiceProvider serviceProvider, Entity entity)
        {
            // Obter o endereço de e-mail do aluno
            string email = entity["E-mail"].ToString();

            // Criar uma mensagem de e-mail
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To = new EmailAddress(email);
            emailMessage.Subject = "Formulário de alunos enviado";
            emailMessage.Body = "Obrigado por enviar o formulário de alunos. Seu cadastro foi recebido com sucesso.";

            // Enviar a mensagem de e-mail
            EmailService.SendEmailAsync(emailMessage);
        }
    }
}
