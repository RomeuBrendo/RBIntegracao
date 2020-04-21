using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioResponse
    {
        public AdicionarUsuarioResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
