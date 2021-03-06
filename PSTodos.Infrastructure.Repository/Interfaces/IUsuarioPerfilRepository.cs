﻿using PSTodos.Model.Entities;

namespace PSTodos.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioPerfilRepository : IBaseRepository<UsuarioPerfil>
    {
        bool Remover(int usuarioId, int perfilId);
        UsuarioPerfil Obter(int usuarioId, int perfilId);
    }
}
