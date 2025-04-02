using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperEvaluation.Application.PessoaJuridica.Create;
using MediatR;

namespace DeveloperEvaluation.Application.PessoaJuridica.Get
{
    public class GetPessoaJuridicaCommand : IRequest<GetPessoaJuridicaResult?>
    {
        public GetPessoaJuridicaCommand(Guid id)
        {
            Id = id;

        }
        public Guid Id { get; private set; }
    }
}
