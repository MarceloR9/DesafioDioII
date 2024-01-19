using Microsoft.Xrm.Sdk.Workflow.Activities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Workflow.ComponentModel.Compiler;
using System.Activities.Expressions;
using System.Net.Mail;
using System.Web;

namespace DesafioDio2
{
    internal class WorkflowCalendario
    {
            public void Execute(IServiceProvider serviceProvider, Entity entity)
            {
            // Validar os dados da inscrição
            // Validar o campo "Curso"
            int cursoId = entity["CursoId"].Value;
            if (cursoId == 0)
            {
                // Exibir uma mensagem de erro
                throw new PluginException(new ValidationErrorCollection()
    {
        new ValidationError("Curso", "O campo Curso é obrigatório")
    });
            }

            // Validar o campo "Aluno"
            int alunoId = entity["AlunoId"].Value;
            if (alunoId == 0)
            {
                // Exibir uma mensagem de erro
                throw new PluginException(new ValidationErrorCollection()
                 {
                  new ValidationError("Aluno", "O campo Aluno é obrigatório")
                 });
            }

            // Salvar a inscrição
            // Salvar a inscrição no banco de dados
            IDataService dataService = serviceProvider.GetService(IDataService);
            dataService.SaveRecord(entity);

            // Enviar notificações sobre a inscrição
            // Obter o registro do aluno
            Entity aluno = serviceProvider.GetService(IDataService).GetRecord("aluno", entity["AlunoId"].Value);

            // Obter o endereço de e-mail do aluno
            string email = aluno["Email"].ToString();

            // Criar uma mensagem de e-mail
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("noreply@seudominio.com.br");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Inscrição em curso";
            mailMessage.Body = "Olá, " + aluno["Nome"].ToString() + 

            "Sua inscrição no curso " + entity["CursoNome"].ToString() + " foi confirmada. As aulas do curso começam em " + entity["DataInicio"].ToString() + ".O horário das aulas é " + entity["Horario"].ToString() + ".Aguardamos sua presença! Atenciosamente,Equipe do sistema"

                 // Enviar a mensagem de e-mail
             SmtpClient smtpClient = new SmtpClient();
              smtpClient.Send(mailMessage);

        }
    }
}
