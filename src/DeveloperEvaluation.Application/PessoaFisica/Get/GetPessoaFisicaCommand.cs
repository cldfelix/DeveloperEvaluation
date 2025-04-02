using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaFisica.Create;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaFisica.Get
{
    public class GetPessoaFisicaCommand : IRequest<GetPessoaFisicaResult?>
    {
        public GetPessoaFisicaCommand(string cpf)
        {
            Cpf = cpf;

        }
        public string Cpf { get; private set; }
    }
}
