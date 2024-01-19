using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace DesafioDio2
{
    internal class PluginPreOperation
    {
        private void OnPreOperation(IServiceProvider serviceProvider, Entity entity)
        {
            // Obter o código de aluno da próxima sequência
            int proximoCodigoAluno = (int)serviceProvider.GetService(ISequenceService).GetNextNumber("CodigoAluno");

            // Atribuir o código de aluno ao registro do aluno
            entity["CodigoAluno"] = proximoCodigoAluno;
        }
    }
}
