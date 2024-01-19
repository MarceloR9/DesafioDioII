using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Workflow.ComponentModel.Compiler;

namespace DesafioDio2
{
    internal class WorkflowInscricao : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider, Entity entity)
        {
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
            // Salvar a inscrição no banco de dados
            IDataService dataService = serviceProvider.GetService(IDataService);
            dataService.SaveRecord(entity);
        }
    }
}
