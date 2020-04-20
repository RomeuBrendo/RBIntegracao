using MediatR;
using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioRequest : IRequest<Response>
    {

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CnpjCpf { get; set; }
        public EnumClienteOuFornecedor ClienteOuFornecedor { get; set; }
    }
}
