using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MudBlazorAlunos.Context;
using MudBlazorAlunos.Entities;

namespace MudBlazorAlunos.Service
{
    public class AlunoService(AppDbContext context) : IAlunoService
    {
        private readonly AppDbContext _context = context;

        public async Task DeletarAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Aluno>> GetAllAlunos()
        {
            return await _context.Alunos.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Aluno> GetAlunoById(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno!;
        }

        public async Task SalvarAluno(Aluno aluno)
        {
            if (aluno.Id == 0)
            {
                await _context.Alunos.AddAsync(aluno);
            }
            else
            {
                _context.Alunos.Update(aluno);
            }
            await _context.SaveChangesAsync();
        }
    }
}