﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario
{
    public class AutenticarUsuarioResquest 
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
