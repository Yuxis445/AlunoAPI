using AlunoApi.Model;

namespace AlunoApi.Service
{
    public interface IAlunoService
    {
        //funcionalidades da Api

        //get todos os alunos
         Task<IEnumerable<Aluno>> GetAlunos();

         //get by id
         Task<Aluno> GetAluno(int id);

         //get by name
         Task<IEnumerable<Aluno>> GetAlunosByNome(string nome);

         Task CreateAluno(Aluno aluno);

        Task UpdateAluno(Aluno aluno);

        Task DeleteAluno(Aluno aluno);
    }
}