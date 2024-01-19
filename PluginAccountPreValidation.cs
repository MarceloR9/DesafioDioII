using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Workflow.ComponentModel.Compiler;
using Microsoft.Crm.Sdk;
using Microsoft.Xrm.Sdk;

namespace DesafioDio2
{
    internal class PluginAccountPreValidation : IPlugin
    {
        private void PluginPreValidation(IServiceProvider serviceProvider, Entity entity)
        {
            // Validar o campo "Nome" para garantir que não esteja vazio
            string nome = entity["Nome"].ToString();
            if (nome.IsNullOrWhitespace())
            {
                // Exibir uma mensagem de erro
                ValidationErrorCollection errosValidacao = new ValidationErrorCollection();
                errosValidacao.Add(new ValidationError("Nome", "O campo Nome não pode estar vazio"));

                // Cancelar a operação de salvamento
                throw new PluginException(errosValidacao);
            }

            // Validar o campo "E-mail" para garantir que seja um endereço de e-mail válido
            string email = entity["E-mail"].ToString();
            if (!EmailAddress.IsValid(email))
            {
                // Exibir uma mensagem de erro
                ValidationErrorCollection errosValidacao = new ValidationErrorCollection();
                errosValidacao.Add(new ValidationError("E-mail", "O campo E-mail não é um endereço de e-mail válido"));

                // Cancelar a operação de salvamento
                throw new PluginException(errosValidacao);
            }

            // Validar o campo "Data de nascimento" para garantir que seja uma data válida
            DateTime dataNascimento = entity["DataNascimento"].Value;
            if (dataNascimento == null || dataNascimento < DateTime.Now.AddYears(-18))
            {
                // Exibir uma mensagem de erro
                ValidationErrorCollection errosValidacao = new ValidationErrorCollection();
                errosValidacao.Add(new ValidationError("DataNascimento", "O campo Data de nascimento deve ser uma data válida e o aluno deve ter mais de 18 anos"));

                // Cancelar a operação de salvamento
                throw new PluginException(errosValidacao);
            }
        }

    }
}
