using LibDDD.Domain.Entities;
using LibDDD.Domain.Interface.Services;
using LibDDD.Domain.Interfaces.Repositories;

namespace LibDDD.Domain.Services
{
    public class EditoraService: ServiceBase<Editora>, IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
            : base(editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }
    }
}
