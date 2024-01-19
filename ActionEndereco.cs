using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Xrm.Sdk;
using System.Workflow.ComponentModel.Compiler;

namespace DesafioDio2
{
    public class ActionEndereco : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obter o registro do aluno
            Entity aluno = serviceProvider.GetService(IDataService).GetRecord("aluno", 1);

            // Validar o campo "Nome"
            string nome = aluno["Nome"].ToString();
            if (string.IsNullOrEmpty(nome))
            {
                // Exibir uma mensagem de erro
                throw new PluginException(new ValidationErrorCollection()
            {
                new ValidationError("Nome", "O campo Nome não pode estar vazio")
            });
            }
        }
    }
}
