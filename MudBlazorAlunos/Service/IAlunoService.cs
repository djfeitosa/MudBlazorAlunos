using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazorAlunos.Entities;

namespace MudBlazorAlunos.Service
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAllAlunos();
        Task<Aluno> GetAlunoById(int id);
        Task SalvarAluno(Aluno aluno);
        Task DeletarAluno(int id);
    }
}